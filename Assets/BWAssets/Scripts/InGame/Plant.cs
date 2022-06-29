using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BWAssets.Game;

namespace BWAssets.Plants
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] private Fruit fruitGO;
        [SerializeField] private Transform[] fruitSpawnPoints;
        [SerializeField] private List<Fruit> fruitRegistered;

        [Space]
        [SerializeField] private GameObject LeafGroup;
        [SerializeField] private LineRenderer[] lineCurves;
        [SerializeField] private int currentLevel;
        [SerializeField] private SubPlant[] plantsAllLevels;
        [SerializeField] private PlantGrowingState[] PlantsStateData;
        [SerializeField] private PlantLevel level;
        [SerializeField] private LineRenderer lineSeed;


        [SerializeField] private float currentTime;
        private int[] thisScaleX = new int[4] { -1, -1, 1, 1 };

        void Awake()
        {
            this.transform.localScale = new Vector3(thisScaleX[Random.Range(0, 3)], this.transform.localScale.y, this.transform.localScale.z);
            currentLevel = 0;
            LeafGroup.SetActive(false);
        }

        void Update()
        {
#if UNITY_EDITOR
            CheatPlantState();
#endif
            if (GameManager.I.IsGameEnded())
                return;

            if (currentLevel == (int)PlantLevel.FullyGrown) 
            {
                for (int i = 0; i < fruitSpawnPoints.Length; i++)
                {
                    if (fruitSpawnPoints[i].childCount > 0) 
                    {
                        return;
                    }
                    SpawnFruits();
                }
            }


            currentTime += Time.deltaTime;
            SetPlantGrowingAnimation();
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
                lineSeed.widthCurve = lineCurves[1].widthCurve;
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
                lineSeed.widthCurve = lineCurves[2].widthCurve;
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
                lineSeed.widthCurve = lineCurves[3].widthCurve;
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
                lineSeed.widthCurve = lineCurves[4].widthCurve;
                lineSeed.numCapVertices = PlantsStateData[4].EndVertex;
                lineSeed.numCornerVertices = PlantsStateData[4].CornerVertex;
                LeafGroup.SetActive(true);
                currentLevel = 4;
            }
            else if (currentTime > PlantsStateData[4].untilTime && currentTime < PlantsStateData[5].untilTime)
            {
                for (int i = 0; i < lineSeed.positionCount - 1; i++)
                {
                    if (lineSeed.GetPosition(i + 1) != PlantsStateData[5].LineSizes[i + 1])
                        lineSeed.SetPosition(i + 1, PlantsStateData[5].LineSizes[i + 1]);
                }
                lineSeed.widthCurve = lineCurves[5].widthCurve;
                lineSeed.numCapVertices = PlantsStateData[5].EndVertex;
                lineSeed.numCornerVertices = PlantsStateData[5].CornerVertex;
                currentLevel = 5;
                lineSeed.material = PlantsStateData[5].Mat;
                level = PlantLevel.Growing;
                LeafGroup.SetActive(true);
            }
            else if (currentTime > PlantsStateData[5].untilTime && currentTime < PlantsStateData[6].untilTime)
            {
                for (int i = 0; i < lineSeed.positionCount - 1; i++)
                {
                    if (lineSeed.GetPosition(i + 1) != PlantsStateData[6].LineSizes[i + 1])
                        lineSeed.SetPosition(i + 1, PlantsStateData[6].LineSizes[i + 1]);
                }
                lineSeed.widthCurve = lineCurves[6].widthCurve;
                lineSeed.material = PlantsStateData[6].Mat;
                lineSeed.numCapVertices = PlantsStateData[6].EndVertex;
                lineSeed.numCornerVertices = PlantsStateData[6].CornerVertex;
                currentLevel = 6;
                level = PlantLevel.FullyGrown;
                LeafGroup.SetActive(true);
            }



        }

        private void SpawnFruits() 
        {
            for (int i = 0; i < fruitSpawnPoints.Length; i++)
            {
                Fruit fr = Instantiate(fruitGO, fruitSpawnPoints[i].position, Quaternion.identity, fruitSpawnPoints[i]);
                fr.name = fruitGO.name + i;
                fruitRegistered.Add(fr);
            }
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
            // public AnimationCurve curve;
            public Color32 LineColor;
            public Vector3[] LineSizes;
            public Material Mat;
            public int CornerVertex, EndVertex;
            public int lineLevelCount;
            public float untilTime;
        }
    }
}