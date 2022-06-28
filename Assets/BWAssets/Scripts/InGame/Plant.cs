using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BWAssets.Plants
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] private int currentLevel;
        [SerializeField] private SubPlant[] plantsAllLevels;
        [SerializeField] private Transform[] fruitSpawnPoints;
        [SerializeField] private PlantGrowingState[] PlantsStateData;
        [SerializeField] private PlantLevel level;
        [SerializeField] private LineRenderer lineSeed;

        [SerializeField] private float currentTime;

        // Start is called before the first frame update
        void Start()
        {
             currentLevel = 0;
        }

        // Update is called once per frame
        void Update()
        {
#if UNITY_EDITOR
            CheatPlantState();
#endif
            currentTime += Time.deltaTime;
            SetPlantGrowingAnimation();
            if (currentLevel == (int)PlantLevel.FullyGrown)
                return;


            // GrowPlant();
        }

        private void GrowSeed()
        {
            if (currentLevel == 999)
                return;

            if (currentLevel == 0)
            {
                if (PlantsStateData[0].LineSizes[1] != PlantsStateData[1].LineSizes[1])
                {
                    // lineSeed.SetPosition(1, PlantGrowingState[]);
                    level = PlantLevel.Sprout;
                    currentLevel = 1;
                }
            }

        }

        private void SetPlantGrowingAnimation()
        {
            lineSeed.startColor = PlantsStateData[currentLevel].LineColor;
            lineSeed.endColor = PlantsStateData[currentLevel].LineColor;

            if (currentTime < PlantsStateData[1].untilTime)
            {
                for (int i = 0; i < lineSeed.positionCount - 1; i++)
                {
                    if (lineSeed.GetPosition(i + 1) != PlantsStateData[1].LineSizes[i + 1])
                        lineSeed.SetPosition(i + 1, PlantsStateData[1].LineSizes[i + 1]);
                }
                lineSeed.numCapVertices = PlantsStateData[1].EndVertex;
                lineSeed.numCornerVertices = PlantsStateData[1].CornerVertex;
                level = PlantLevel.Sprout;
                currentLevel = 1;
            }
            else if (currentTime > PlantsStateData[1].untilTime && currentTime < PlantsStateData[2].untilTime)
            {
                for (int i = 0; i < lineSeed.positionCount - 1; i++)
                {
                    if (lineSeed.GetPosition(i + 1) != PlantsStateData[2].LineSizes[i + 1])
                        lineSeed.SetPosition(i + 1, PlantsStateData[2].LineSizes[i + 1]);
                }
                lineSeed.numCapVertices = PlantsStateData[2].EndVertex;
                lineSeed.numCornerVertices = PlantsStateData[2].CornerVertex;
                currentLevel = 2;
            }
            else if (currentTime > PlantsStateData[2].untilTime && currentTime < PlantsStateData[3].untilTime)
            {
                for (int i = 0; i < lineSeed.positionCount - 1; i++)
                {
                    if (lineSeed.GetPosition(i + 1) != PlantsStateData[3].LineSizes[i + 1])
                        lineSeed.SetPosition(i + 1, PlantsStateData[3].LineSizes[i + 1]);
                }
                lineSeed.numCapVertices = PlantsStateData[3].EndVertex;
                lineSeed.numCornerVertices = PlantsStateData[3].CornerVertex;
                currentLevel = 3;
            }
            else if (currentTime > PlantsStateData[3].untilTime && currentTime < PlantsStateData[4].untilTime)
            {
                for (int i = 0; i < lineSeed.positionCount - 1; i++)
                {
                    if (lineSeed.GetPosition(i + 1) != PlantsStateData[4].LineSizes[i + 1])
                        lineSeed.SetPosition(i + 1, PlantsStateData[4].LineSizes[i + 1]);
                }
                lineSeed.numCapVertices = PlantsStateData[4].EndVertex;
                lineSeed.numCornerVertices = PlantsStateData[4].CornerVertex;
                currentLevel = 4;
            }
            else if (currentTime > PlantsStateData[4].untilTime && currentTime < PlantsStateData[5].untilTime)
            {
                for (int i = 0; i < lineSeed.positionCount - 1; i++)
                {
                    if (lineSeed.GetPosition(i + 1) != PlantsStateData[5].LineSizes[i + 1])
                        lineSeed.SetPosition(i + 1, PlantsStateData[5].LineSizes[i + 1]);
                }
                lineSeed.numCapVertices = PlantsStateData[5].EndVertex;
                lineSeed.numCornerVertices = PlantsStateData[5].CornerVertex;
                currentLevel = 5;
                level = PlantLevel.Growing;
            }
            else if (currentTime > PlantsStateData[5].untilTime && currentTime < PlantsStateData[6].untilTime)
            {
                for (int i = 0; i < lineSeed.positionCount - 1; i++)
                {
                    if (lineSeed.GetPosition(i + 1) != PlantsStateData[6].LineSizes[i + 1])
                        lineSeed.SetPosition(i + 1, PlantsStateData[6].LineSizes[i + 1]);
                }
                lineSeed.numCapVertices = PlantsStateData[6].EndVertex;
                lineSeed.numCornerVertices = PlantsStateData[6].CornerVertex;
                currentLevel = 6;
                level = PlantLevel.FullyGrown;
            }

        }

        private IEnumerator AnimatePlant()
        {
            float sugmentDuration = PlantsStateData[PlantsStateData.Length - 1].untilTime / PlantsStateData.Length - 1;

            for (int i = 0; i < PlantsStateData.Length - 1; i++)
            {
                float startTime = Time.time;
                for (int j = 1; j < lineSeed.positionCount; j++)
                {

                }
                Vector3 startPos = PlantsStateData[i].LineSizes[i];
                Vector3 endPos = PlantsStateData[i].LineSizes[i + 1];
            }
            yield return null;
        }

#if UNITY_EDITOR
        private void CheatPlantState()
        {
            if (currentLevel == 999)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if ((int)level >= (int)PlantLevel.FullyGrown)
                        return;

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
            public int lineCount => LineSizes.Length;
            public float untilTime;
        }
    }
}