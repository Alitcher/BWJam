using BWAssets.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelDefeatedPopup : BasePopup
{
    [SerializeField] private Button RestartBtn, MenuBtn;
    [SerializeField] private Text reasonTxt;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        RestartBtn.onClick.AddListener(OnRestartClick);
        MenuBtn.onClick.AddListener(OnMenuClick);

        reasonTxt.text = (GameManager.I.HP <= 0) ? "your life is running out." : "you didn't collect enough money.";
    }

    protected void OnRestartClick()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Gameplay");
    }
}
