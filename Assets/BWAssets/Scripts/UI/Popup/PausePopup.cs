using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePopup : BasePopup
{
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button MenuButton;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        ResumeButton.onClick.AddListener(OnResumeClick);
        MenuButton.onClick.AddListener(OnMenuClick);
        RestartButton.onClick.AddListener(OnRestartClick);
    }

    protected void OnRestartClick()
    {
        SceneManager.LoadScene("Gameplay");
    }

    protected void OnResumeClick()
    {
    }
}
