using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BWConfig", menuName = "ScriptableObjects/BWConfig", order = 0)]
public class BWConfig : ScriptableObject
{
    public Color32 Green;
    public Color32 Yellow;

    public float MoneyGoalToBeatLevel;
    public int GameTimeInSeconds;
    public int PlayerLevel => Mathf.RoundToInt(MoneyGoalToBeatLevel / 500);
}

public enum GameState 
{
    None,
    Tutorial,
    Gameplay
}