using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDefeatedPopup : BasePopup
{
    [SerializeField] private Button RestartBtn, MenuBtn;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        RestartBtn.onClick.AddListener(OnRestartClick);
        MenuBtn.onClick.AddListener(OnMenuClick);
    }

    protected void OnRestartClick()
    {

    }
}
