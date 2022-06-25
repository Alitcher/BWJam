using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWAssets.Plants
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] private int currentLevel;
        [SerializeField] private Sprite[] plantSpritePreset;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x + 0.1f * Time.deltaTime, this.transform.localScale.y + 0.1f * Time.deltaTime, this.transform.localScale.z);
        }
    }
}