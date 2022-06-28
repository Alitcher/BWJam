using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button shopBtn;
    [SerializeField] private Button playBtn;
    [SerializeField] private Button creditBtn;

    [SerializeField] private GameObject menuPanel, creditPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ShowCredit() 
    {
        creditPanel.SetActive(true);
    }
}
