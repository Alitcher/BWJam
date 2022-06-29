using BWAssets.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitpointGroup : MonoBehaviour
{
    [SerializeField] private List<GameObject> HeartGroup = new List<GameObject>();
    [SerializeField] private GameObject Heart;
    [SerializeField] private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameManager.I.HP; i++)
        {
            SpawnHeart();
        }
        GameManager.I.OnHPIncrease += SpawnHeart;
        GameManager.I.OnHPDecrease += ReduceHeart;
    }

    public void ReduceHeart() 
    {
        for (int i = HeartGroup.Count-1; i >= GameManager.I.HP; i--)
        {
            HeartGroup[i].SetActive(false);
        }
    }

    public void SpawnHeart()
    {
        GameObject h = Instantiate(Heart, this.rect, this.transform);
        h.name = $"{Heart.name}_{HeartGroup.Count}";
        HeartGroup.Add(h);
    }
}
