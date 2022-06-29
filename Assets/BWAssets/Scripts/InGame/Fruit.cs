using BWAssets.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWAssets.Plants
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private float currentTime;
        [SerializeField] private Seed seedGo;
        [SerializeField] private Rigidbody2D rigid;
        [SerializeField] private GameObject particleExplo;
        [SerializeField] private GameObject[] fruitGroup;
        [SerializeField] private int currentLevel;

        [SerializeField] private FruitConfig config;

        private bool hitGround = false;

        // Start is called before the first frame update
        void Start()
        {
            currentTime = 0;
            currentLevel = 0;
            fruitGroup[currentLevel].SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.I.IsGameEnded())
                return;
            currentTime += Time.deltaTime;
            SetFruitState();
        }


        private void SetFruitState()
        {
            if (hitGround) return;
            rigid.bodyType = (currentLevel >= (int)FruitLevel.Falling) ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;

            if (currentTime < config.FruitEachTime[1])
            {
                currentLevel = 1;
            }
            if (currentTime > config.FruitEachTime[1] && currentTime < config.FruitEachTime[2])
            {
                currentLevel = 2;
            }
            if (currentTime > config.FruitEachTime[2] && currentTime < config.FruitEachTime[3])
            {
                currentLevel = 3;
            }
            if (currentTime > config.FruitEachTime[3] && currentTime < config.FruitEachTime[4])
            {
                currentLevel = 4;
            }
            if (currentTime > config.FruitEachTime[4] && currentTime < config.FruitEachTime[5])
            {
                currentLevel = 5;
            }
            if (currentTime > config.FruitEachTime[5] && currentTime < config.FruitEachTime[6])
            {
                currentLevel = 6;
                SoundManager.I.Play2("FruitGrow");

            }
            else if (currentTime > config.FruitEachTime[6])
            {
                SoundManager.I.Play2("FruitGrow");

                fruitGroup[6].SetActive(true);
                currentLevel = 7;
            }

            if (currentLevel < 7)
            {
                for (int i = 0; i < fruitGroup.Length; i++)
                {
                    fruitGroup[i].SetActive(i == currentLevel);
                }
            }


        }

        private void OnMouseDown()
        {
            if (currentLevel > (int)FruitLevel.TooYoung)
            {
                SoundManager.I?.Play("FruitCollected");
                GameManager.I.IncreaseMoney(5 * currentLevel);
                Destroy(this.gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground" && currentLevel == (int)FruitLevel.Falling)
            {
                hitGround = true;
                foreach (var fruit in fruitGroup)
                {
                    fruit.SetActive(false);
                }
                particleExplo.SetActive(true);
                SoundManager.I?.Play2("FruitDrop");
                GameManager.I.shakerRef.ShakeLayer();
                GameManager.I.DecreaseHP();
                SpawnSeedAfterdeath();
                Destroy(this.gameObject, 0.5f);
            }
        }

        private void SpawnSeedAfterdeath()
        {
            Seed seed = Instantiate(seedGo, this.transform.position, Quaternion.identity, GameManager.I.parallaxEnv);
            seed.name = seedGo.name;
            seed.gameObject.SetActive(true);
        }

    }
}