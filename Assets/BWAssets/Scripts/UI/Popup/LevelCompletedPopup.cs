using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using BWAssets.Game;

public class LevelCompletedPopup : BasePopup
{
    [SerializeField] private Button menuBtn;
    [SerializeField] private Button lextLvBtn;
    [SerializeField] private Text bonusTxt;
    [SerializeField] private Text nextLvTxt;
    // Start is called before the first frame update

    public override void Start()
    {
        base.Start();
        nextLvTxt.text = $"Lv: {GameManager.I.ConfigRef.PlayerLevel} Money goal: {GameManager.I.ConfigRef.MoneyGoalToBeatLevel}";
        bonusTxt.text = $"Bonus +{GameManager.I.CurrentGameTime}";
        menuBtn.onClick.AddListener(OnMenuClick);
    }

    public void OnNextLevelClick() 
    {
        SceneManager.LoadScene("Gameplay");
    }
}
