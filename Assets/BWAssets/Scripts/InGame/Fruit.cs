using BWAssets.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWAssets.Plants
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private GameObject particleExplo;
        [SerializeField] private GameObject[] fruitGroup;
        [SerializeField] private int currentLevel;

        [SerializeField] private FruitConfig fruitPreset;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnMouseDown()
        {
            Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                foreach (var fruit in fruitGroup)
                {
                    fruit.SetActive(false);
                }
                particleExplo.SetActive(true);
                GameManager.I.shakerRef.ShakeLayer();
                Destroy(this.gameObject, 0.5f);
            }
        }
    }
}