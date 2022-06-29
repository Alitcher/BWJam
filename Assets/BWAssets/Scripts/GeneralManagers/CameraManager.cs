using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BWAssets.Game;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CameraScaleValues[] CameraOnProgress = new CameraScaleValues[3];
    [SerializeField] private AudioSource ss;
    public void CheckCurrentProgress(GameProgress progress)
    {
        if ((int)progress >= CameraOnProgress.Length) 
            return;

        //SoundManager.I.Play2("CameraExpand");
        ss.Play();
        Camera.main.transform.DOLocalMoveY(CameraOnProgress[(int)progress].YValues, CameraOnProgress[(int)progress].duration);
        Camera.main.DOOrthoSize(CameraOnProgress[(int)progress].Size, CameraOnProgress[(int)progress].duration);
    }

    [System.Serializable]
    public struct CameraScaleValues
    {
        public float YValues;
        public float Size;
        public float duration;
    }
}
