using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BWAssets.Game;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CameraScaleValues[] CameraOnProgress = new CameraScaleValues[3];
    [SerializeField] private AudioSource ss;

    public void CheckCurrentProgress(int playerLv)
    {
        if (playerLv >= CameraOnProgress.Length) 
            return;

        //SoundManager.I.Play2("CameraExpand");
        ss.Play();
        Camera.main.transform.DOLocalMoveY(CameraOnProgress[playerLv].YValues, CameraOnProgress[playerLv].duration);
        Camera.main.DOOrthoSize(CameraOnProgress[playerLv].Size, CameraOnProgress[playerLv].duration);
    }

    [System.Serializable]
    public struct CameraScaleValues
    {
        public float YValues;
        public float Size;
        public float duration;
    }
}
