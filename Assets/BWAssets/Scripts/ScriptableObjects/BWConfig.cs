﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BWConfig", menuName = "ScriptableObjects/BWConfig", order = 0)]
public class BWConfig : ScriptableObject
{
    public Color32 Green;
    public Color32 Yellow;

    public float[] plantLevelScale;
    public float[] fruitLevelScale;
}
