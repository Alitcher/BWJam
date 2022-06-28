using BWAssets.Plants;
using BWAssets.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BWAssets.Game
{
    public class GameManager : GenericSingleton<GameManager>
    {
        [SerializeField] private DevDebugPanel devPanel;
        [SerializeField] private CameraManager camManagerRef;

        public int HP { get; private set; }
        public float MoneyCollected { get; private set; }
        public int CurrentGameTime; 
        public BWConfig ConfigRef;
        public List<GameObject> RegisteredSeeds;
        public List<Plant> RegisteredPlants;
        public LayerShaker shakerRef;
        public GameProgress CurrentProgress;

        public Action OnHPIncrease;
        public Action<float> OnMoneyIncrease;

        // Start is called before the first frame update
        public override void Awake()
        {
            base.Awake();
            HP = 3;
            MoneyCollected = 0;
            CurrentGameTime = ConfigRef.GameTimeInSeconds;
           // CurrentProgress = GameProgress.JustStarted;
            camManagerRef.CheckCurrentProgress(CurrentProgress);

            InvokeRepeating("CountDownTime", 1.0f,1.0f);
        }

        public void IncreaseHP() 
        {
            HP++;
            OnHPIncrease.Invoke();
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CurrentProgress < GameProgress.Max)
                    CurrentProgress++;
                camManagerRef.CheckCurrentProgress(CurrentProgress);
            }
        }
    }
}

