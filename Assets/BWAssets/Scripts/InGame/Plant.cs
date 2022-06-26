using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWAssets.Plants
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] private int currentLevel;
        [SerializeField] private Plant[] plantsAllLevels;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (currentLevel == (int)PlantLevel.FullyGrown)
                return;
            if (currentLevel == 999)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    int thisTestLv = 1;
                    for (int i = 0; i < plantsAllLevels.Length; i++)
                    {
                        if (plantsAllLevels[i].currentLevel == thisTestLv) 
                        {
                            plantsAllLevels[thisTestLv].gameObject.SetActive(true);
                            thisTestLv++;
                            return;
                        }
                        plantsAllLevels[thisTestLv].gameObject.SetActive(false);

                    }
                }
            }
            this.transform.localScale = new Vector3(this.transform.localScale.x + 0.1f * Time.deltaTime, this.transform.localScale.y + 0.1f * Time.deltaTime, this.transform.localScale.z);
        }
    }
}