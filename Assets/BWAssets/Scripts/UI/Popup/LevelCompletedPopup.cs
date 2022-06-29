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
    // Start is called before the first frame update

   public override void Start()
    {
        base.Start();
        bonusTxt.text = $"Bonus +{GameManager.I.CurrentGameTime}";
        menuBtn.onClick.AddListener(OnMenuClick);
    }

    public void OnNextLevelClick() 
    {
        SceneManager.LoadScene("Gameplay");
    }
}
