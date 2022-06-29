using BWAssets.Plants;
using BWAssets.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BWAssets.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager I { get { return _instance; } }
        private static GameManager _instance;

        [SerializeField] private DevDebugPanel devPanel;
        [SerializeField] private CameraManager camManagerRef;
        [SerializeField] private AudioSource bgm;
        public int HP { get; private set; }
        public float MoneyCollected { get; private set; }
        public int CurrentGameTime;
        public BWConfig ConfigRef;
        public List<GameObject> RegisteredSeeds;
        public List<Plant> RegisteredPlants;
        public LayerShaker shakerRef;
        public GameProgress CurrentProgress;
        public Transform parallaxEnv;
        public Action OnHPIncrease, OnHPDecrease, OnGameDefeated, OnGameWon;
        public Action<float> OnMoneyIncrease;

        public bool IsGamePaused;
        public bool IsGameEnded()
        {
            return HP <= 0 || (CurrentGameTime <= 0 && MoneyCollected >= ConfigRef.MoneyGoalToBeatLevel);
        }

        public bool IsGameWon() 
        {
            return HP > 0 && (CurrentGameTime > 0 && MoneyCollected >= ConfigRef.MoneyGoalToBeatLevel);
        }


        public void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
                return;//Avoid doing anything else
            }
            if (_instance == null)
            {
                _instance = this;
                //  DontDestroyOnLoad(this.gameObject);
            }

            HP = 3;
            MoneyCollected = 0;
            Time.timeScale = 1;
            CurrentGameTime = ConfigRef.GameTimeInSeconds;
            // CurrentProgress = GameProgress.JustStarted;
            camManagerRef.CheckCurrentProgress(CurrentProgress);

            InvokeRepeating("CountDownTime", 1.0f, 1.0f);
        }

        public void IncreaseHP()
        {
            HP++;
            OnHPIncrease.Invoke();
        }

        public void DecreaseHP()
        {
            if (HP > 0)
            {
                HP--;
            }
            OnHPDecrease.Invoke();
        }

        public void CountDownTime()
        {
            CurrentGameTime--;
        }

        public void IncreaseMoney(float earnedAmount)
        {
            MoneyCollected += earnedAmount;
            OnMoneyIncrease.Invoke(MoneyCollected);
        }

        // Update is called once per frame
        void Update()
        {
            if (CurrentGameTime <= 90)
            {
                CurrentProgress = GameProgress.Max;
                camManagerRef.CheckCurrentProgress(CurrentProgress);
            }

            if (IsGameEnded())
            {
                Time.timeScale = 0;
                bgm.Stop();
                OnGameDefeated.Invoke();
                return;
            }
            else if (IsGameWon()) 
            {
                ConfigRef.MoneyGoalToBeatLevel += 500;
                Time.timeScale = 0;
                bgm.Stop();
                SoundManager.I.Play("GameWon");
                OnGameWon.Invoke();
                return;
            }
#if(UNITY_EDITOR)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CurrentProgress < GameProgress.Max)
                    CurrentProgress++;
                camManagerRef.CheckCurrentProgress(CurrentProgress);
            }
#endif
        }
    }
}

