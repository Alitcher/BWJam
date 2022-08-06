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

    [SerializeField] private Text moneyGoalText, LevelText, versionText;
    [SerializeField] private BWConfig config;
    [SerializeField] private GameObject menuPanel, creditPanel, menuContent;

    public void Start()
    {
        versionText.text = $"v{Application.version}";
        moneyGoalText.text = $"Money goal: ${config.MoneyGoalToBeatLevel}";
        LevelText.text = $"Level: {config.PlayerLevel}";
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ShowCredit() 
    {
        creditPanel.SetActive(true);
        menuContent.SetActive(false);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
