using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BWAssets.Plants
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] private PlantConfig config;
        [SerializeField] private int currentLevel;
        [SerializeField] private SubPlant[] plantsAllLevels;
        [SerializeField] private Transform[] fruitSpawnPoints;
        [SerializeField] private PlantGrowingState[] PlantsStateData;
        [SerializeField] private PlantLevel level;
        [SerializeField] private LineRenderer lineSeed;

        [SerializeField] private float currentTime;
        private float totalTime => config.GrowingRate[6];

        // Start is called before the first frame update
        void Start()
        {
           // currentLevel = 0;
        }

        // Update is called once per frame
        void Update()
        {
#if UNITY_EDITOR
            TestPlantState();
#endif
            currentTime += Time.deltaTime;
            //CheckDuration();
            if (currentLevel == (int)PlantLevel.FullyGrown)
                return;


           // GrowPlant();
        }

        private void CheckDuration()
        {
            if (currentTime > config.GrowingRate[0] && currentTime < config.GrowingRate[1])
            {
                level = PlantLevel.Sprout;
                currentLevel = 1;
            }
            else if (currentTime > config.GrowingRate[1] && currentTime < config.GrowingRate[2])
            {
                level = PlantLevel.Sprout;
                currentLevel = 2;
            }
            else if (currentTime > config.GrowingRate[2] && currentTime < config.GrowingRate[3])
            {
                level = PlantLevel.Sprout;
                currentLevel = 3;
            }
            else if (currentTime > config.GrowingRate[3] && currentTime < config.GrowingRate[4])
            {
                level = PlantLevel.Growing;
                currentLevel = 4;
            }
            else if (currentTime > config.GrowingRate[4] && currentTime < config.GrowingRate[5])
            {
                level = PlantLevel.Growing;
                currentLevel = 5;
            }
            else if (currentTime > config.GrowingRate[5] && currentTime < config.GrowingRate[6])
            {
                level = PlantLevel.FullyGrown;
                currentLevel = 6;
            }
            else if (currentTime > config.GrowingRate[6])
            {
                level = PlantLevel.FullyGrown;
                currentLevel = 7;
            }
        }

        private void GrowPlant()
        {
            switch (level)
            {
                case PlantLevel.Seed:
                    GrowSeedToSprout();
                    break;
                case PlantLevel.Sprout:
                    //lineSeed.SetColors(PlantsStateData[1].LineColor, PlantsStateData[1].LineColor);
                    //for (int i = 0; i < lineSeed.positionCount; i++)
                    //{
                    //    lineSeed.SetPosition(i, PlantsStateData[1].LineSizes[i]);
                    //}
                    //lineSeed.SetVertexCount(PlantsStateData[1].CornerVertex);
                    break;
                case PlantLevel.Growing:
                    break;
                case PlantLevel.FullyGrown:
                    break;
                case PlantLevel.None:
                    break;
                default:
                    break;
            }
        }

        private void GrowSeedToSprout()
        {
            while (currentLevel <= (int)PlantLevel.Sprout)
            {
                dd();
            }
            level = PlantLevel.Growing;
        }

        private void dd()
        {
            lineSeed.startColor = PlantsStateData[currentLevel].LineColor;
            lineSeed.endColor = PlantsStateData[currentLevel].LineColor;

            for (int i = 0; i < lineSeed.positionCount; i++)
            {
                if (lineSeed.GetPosition(i) != PlantsStateData[currentLevel].LineSizes[i])
                    lineSeed.SetPosition(i, PlantsStateData[currentLevel].LineSizes[i]);
            }
            lineSeed.numCapVertices = PlantsStateData[currentLevel].EndVertex;
            lineSeed.numCornerVertices = PlantsStateData[currentLevel].CornerVertex;

            if (currentLevel < PlantsStateData.Length - 1)
                while (lineSeed.positionCount < PlantsStateData[currentLevel + 1].LineSizes.Length)
                {
                    lineSeed.positionCount++;
                }
        }

#if UNITY_EDITOR
        private void TestPlantState()
        {
            if (currentLevel == 999)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    for (int i = 0; i < plantsAllLevels.Length; i++)
                    {
                        plantsAllLevels[i].gameObject.SetActive((plantsAllLevels[i].currentLevel == (int)level));
                    }
                    level++;
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    for (int i = 0; i < plantsAllLevels.Length; i++)
                    {
                        plantsAllLevels[i].gameObject.SetActive(plantsAllLevels[i].currentLevel == 1);
                    }
                    level = PlantLevel.Seed;
                }
            }
        }
#endif
        [System.Serializable]
        public struct PlantGrowingState
        {
            // public curve
            public Color32 LineColor;
            public Vector3[] LineSizes;
            public Material Mat;
            public int CornerVertex, EndVertex;
        }
    }
}