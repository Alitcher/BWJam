using BWAssets.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private DevDebugPanel devPanel;
    private bool isDebugPanelOn;
#endif
    [SerializeField] private Button MenuButton;
    [SerializeField] private LevelCompletedPopup levelCompletedPopup;
    [SerializeField] private LevelDefeatedPopup levelDefeatedPopup;
    [SerializeField] private PausePopup pausePopup;
    [SerializeField] private MoneyBar moneyBar;

    // Start is called before the first frame update
    void Start()
    {
        MenuButton.onClick.AddListener(OnGamePaused);
        GameManager.I.OnGameWon += () => levelCompletedPopup.gameObject.SetActive(true);
        GameManager.I.OnGameDefeated += () => levelDefeatedPopup.gameObject.SetActive(true);
    }

#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            devPanel.gameObject.SetActive(!isDebugPanelOn);
            isDebugPanelOn = !isDebugPanelOn;
        }
    }
#endif

    public void OnGamePaused() 
    {
        GameManager.I.IsGamePaused = true;
        Time.timeScale = 0;
        pausePopup.gameObject.SetActive(true);
        SoundManager.I.Play2("ButtonClick");
    }

}
