using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BWAssets.Plants;
using BWAssets.Game;

public class Seed : MonoBehaviour
{
    [SerializeField] private BWConfig config;
    [SerializeField] private SpriteRenderer seedSprite;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private CircleCollider2D coll;

    [SerializeField] private Plant plantGo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float startPos = 0;
        if (collision.gameObject.tag == "Ground") 
        {
            if (startPos == 0) 
            {
                startPos = this.transform.position.y;
            }
            seedSprite.color = config.Yellow;
            coll.isTrigger = true;
            rigid.gravityScale =0;
            this.transform.DOLocalMoveY(Random.Range(startPos, -6), 1).OnComplete(() => Destroy(coll)).OnComplete(SpawnSprout);
            Destroy(rigid);
        }
    }

    private void SpawnSprout()
    {
        Plant plant = Instantiate(plantGo, this.transform.localPosition ,Quaternion.identity, GameManager.I.parallaxEnv);
        plant.name = plantGo.name;
        plant.gameObject.SetActive(true);
    }
}
