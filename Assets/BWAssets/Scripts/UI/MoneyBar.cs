using BWAssets.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private Slider moneySlider;
    [SerializeField] private Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
            GameManager.I.OnMoneyIncrease += CheckMoney;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckMoney(float currentMoney)
    {
        moneyText.text = $"{currentMoney}";
        moneySlider.value = GameManager.I.MoneyCollected / GameManager.I.ConfigRef.MoneyGoalToBeatLevel;
    }
}
