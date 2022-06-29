using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FruitConfig", menuName = "ScriptableObjects/FruitConfig", order = 1)]
public class FruitConfig : ScriptableObject
{
    public FruitLevelValues[] LevelScaleValues;
    public float FruitLifeTime;
    public float[] FruitEachTime;

    [System.Serializable]
    public class FruitLevelValues
    {
        public Sprite fruitPic;
        public float LevelScaleValues;
        public Vector2 Offset;
        public float Radius;
        public bool IsCollectable;
    }
}

