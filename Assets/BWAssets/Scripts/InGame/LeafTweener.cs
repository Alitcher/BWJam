using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LeafTweener : MonoBehaviour
{
    [SerializeField] private Transform leafTransform;
    [SerializeField] private Vector3[] rotateValues;

    [SerializeField] private float duration;

    private Sequence tween;

    void Start()
    {
        this.transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotateValues[1].z);
        RotateLeaf();
    }

    public void RotateLeaf()
    {
        if (tween == null)
        {
            tween = DOTween.Sequence()
                      .Append(this.transform.DOLocalRotate(rotateValues[0], duration))
                      .Append(this.transform.DOLocalRotate(rotateValues[1], duration)).SetLoops(-1);
        }

        //this.transform.DOLocalRotate(rotateValues[0], duration)
        //    .OnComplete(() => this.transform.DOLocalRotate(rotateValues[1], duration)
        //    .OnComplete(() => this.transform.DOLocalRotate(rotateValues[0], duration))).SetLoops(999);

    }
}
