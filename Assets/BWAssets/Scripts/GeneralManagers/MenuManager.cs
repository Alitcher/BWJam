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
    [SerializeField] private Button quitBtn;

    [SerializeField] private Text moneyGoalText, LevelText;
    [SerializeField] private BWConfig config;
    [SerializeField] private GameObject menuPanel, creditPanel;

    public void Start()
    {
        moneyGoalText.text = $"Money goal: ${config.MoneyGoalToBeatLevel}";
        LevelText.text = $"Level: {config.MoneyGoalToBeatLevel / 500}";
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ShowCredit() 
    {
        creditPanel.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
