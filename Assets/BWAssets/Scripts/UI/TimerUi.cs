using BWAssets.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUi : MonoBehaviour
{
    [SerializeField] private Text TimeText;
    [SerializeField] private Image clockImg;
    void Update()
    {
        if (GameManager.I.CurrentProgress == GameProgress.Tutorial) return;
        clockImg.fillAmount -= 0.0083333333333f * Time.deltaTime;
        TimeText.text = $"{GameManager.I.CurrentGameTime}";
    }
}
