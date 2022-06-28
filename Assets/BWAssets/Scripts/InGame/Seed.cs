﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BWAssets.Plants;

public class Seed : MonoBehaviour
{
    [SerializeField] private BWConfig config;
    [SerializeField] private SpriteRenderer seedSprite;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private CircleCollider2D coll;

    [SerializeField] private Plant plantGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            seedSprite.color = config.Yellow;
            coll.isTrigger = true;
            rigid.gravityScale =0;
            this.transform.DOLocalMoveY(Random.Range(-5.6f, -6), 1).OnComplete(() => Destroy(coll)).OnComplete(SpawnSprout);
            Destroy(rigid);
        }
    }

    private void SpawnSprout()
    {
        Plant plant = Instantiate(plantGo, this.transform.position,Quaternion.identity, this.transform);
        plant.name = plantGo.name;

        plant.gameObject.SetActive(true);
    }
}