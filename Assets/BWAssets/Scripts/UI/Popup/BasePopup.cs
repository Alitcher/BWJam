using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePopup : MonoBehaviour
{
    [SerializeField] private Button CloseButton;

    public virtual void Start()
    {
        CloseButton.onClick.AddListener(HidePopup);
    }
    private void OnMouseUpAsButton()
    {
        
    }
    protected void OnClosePopup() 
    {
    
    }

    protected void HidePopup() 
    {
        this.gameObject.SetActive(false);
    }
}
