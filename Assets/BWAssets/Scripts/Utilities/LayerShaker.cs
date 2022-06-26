using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace BWAssets.Utils 
{
    public class LayerShaker : MonoBehaviour
    {
        [SerializeField] private float shakeDuration, shakePower;
        [SerializeField] private Vector3 originalPos;

        private float currentShakeDuration;
        // Start is called before the first frame update
        void Awake()
        {
            originalPos = this.transform.position;
            currentShakeDuration = shakeDuration;
        }

        private IEnumerator ShakeLayerCoroutine()
        {
            while (currentShakeDuration > 0)
            {
                currentShakeDuration -= Time.deltaTime;
                Vector2 ShakePos = Random.insideUnitCircle * shakePower;
                this.transform.DOBlendableLocalMoveBy(new Vector2(originalPos.x + ShakePos.x, originalPos.y + ShakePos.y), shakeDuration).SetEase(Ease.OutElastic)
                    .OnComplete(() => this.transform.position = originalPos); //use this to shake both x and y
                yield return null;
            }
        }

        public void ShakeLayer()
        {
            currentShakeDuration = shakeDuration;
            StartCoroutine(ShakeLayerCoroutine());
        }
    }
}

