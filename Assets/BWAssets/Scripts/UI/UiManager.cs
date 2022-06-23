﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private DevDebugPanel devPanel;
    private bool isDebugPanelOn;
#endif
    // Start is called before the first frame update
    void Start()
    {
        
    }

#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            devPanel.gameObject.SetActive(!isDebugPanelOn);
            isDebugPanelOn = !isDebugPanelOn;
        }
    }
#endif
}