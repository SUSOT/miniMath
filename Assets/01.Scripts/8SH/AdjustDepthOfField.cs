using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AdjustDepthOfField : MonoBehaviour
{
    private Volume volume;
    private DepthOfField depthOfField;

    private void Awake()
    {
        volume = GetComponent<Volume>();
        DepthOfField DOF;
        if (volume.profile.TryGet(out DOF))
        {
            depthOfField = DOF;
        }
        depthOfField.focalLength.value = 0;
    } 

    public  void Adjust()
    {
        if (depthOfField)
        {
            DOTween.To(() => 0, x => depthOfField.focalLength.value = x, 200, 1).Play();
        }
    }
}
