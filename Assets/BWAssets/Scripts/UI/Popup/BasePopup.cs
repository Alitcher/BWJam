using BWAssets.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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


    protected void OnMenuClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    protected void HidePopup() 
    {
        this.gameObject.SetActive(false);
        GameManager.I.IsGamePaused = false;
        Time.timeScale = 1;
    }
}
