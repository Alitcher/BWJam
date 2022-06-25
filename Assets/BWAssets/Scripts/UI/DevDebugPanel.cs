using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevDebugPanel : MonoBehaviour
{
    [SerializeField] private Button shakeLayerBtn;
    [SerializeField] private GameObject fruit;

    public void DropFruit() 
    {
        Instantiate(fruit,Vector3.zero, Quaternion.identity);
    }
}
