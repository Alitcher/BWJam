﻿using BWAssets.Game;
using BWAssets.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject dragDropInGame;
    [SerializeField] private Image dragDropSelf;
    [SerializeField] private RectTransform thisRect;
    [SerializeField] private Vector3 OriginalPos;
    [SerializeField] private ItemType itemType;
    private GameObject go;

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (itemType)
        {
            case ItemType.Seed:
                OriginalPos = this.transform.position;
                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f);
                this.gameObject.transform.position = mousePos;
                break;
            case ItemType.Heart:
                GameManager.I.IncreaseHP();
                Destroy(this.gameObject);
                break;
            case ItemType.Spray:
                break;
            default:
                break;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (thisRect.anchoredPosition.y > 100f)
        {
            this.gameObject.SetActive(false);
            go = Instantiate(dragDropInGame, Camera.main.ScreenToWorldPoint(GetMousePos()), Quaternion.identity);
            GameManager.I.RegisteredSeeds.Add(go);
        }
        else
        {
            this.gameObject.transform.position = OriginalPos;

        }
    }

    Vector3 GetMousePos()
    {
        return new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
    }

    public void OnPointerDrag()
    {
        this.gameObject.transform.position = GetMousePos();
        dragDropSelf.color = (thisRect.anchoredPosition.y > 150f) ? GameManager.I.ConfigRef.Green : GameManager.I.ConfigRef.Yellow;
    }

}
