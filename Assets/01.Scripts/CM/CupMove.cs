using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CupMove : MonoBehaviour
{
    [SerializeField] private GameObject cup1;
    [SerializeField] private GameObject cup2;
    [SerializeField] private GameObject cup3;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private float _shakeDuration = 0.5f;

    private bool IsShakeEnd = false;
    private float curTime;
    private void Start()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= 4.5f)
            IsShakeEnd = true;
    }

    public void OpenCup()
    {
        if (IsShakeEnd == true)
        {
            cup1.transform.DOMoveY(3, _duration);
            cup2.transform.DOMoveY(3, _duration);
            cup3.transform.DOMoveY(3, _duration);
        }
    }

    private IEnumerator ShakeCoroutine()
    {
        cup1.transform.DOMoveX(5, _shakeDuration);
        cup2.transform.DOMoveX(-5, _shakeDuration);
        cup3.transform.DOMoveX(-2, _shakeDuration);
        yield return new WaitForSeconds(_shakeDuration + _shakeDuration);
        cup1.transform.DOMoveX(-3, _shakeDuration);
        cup2.transform.DOMoveX(6, _shakeDuration);
        cup3.transform.DOMoveX(2, _shakeDuration);
        yield return new WaitForSeconds(_shakeDuration + _shakeDuration);
        cup1.transform.DOMoveX(2, _shakeDuration);
        cup2.transform.DOMoveX(-5, _shakeDuration);
        cup3.transform.DOMoveX(-2, _shakeDuration);
        yield return new WaitForSeconds(_shakeDuration + _shakeDuration);
        cup1.transform.DOMoveX(-6, _shakeDuration);
        cup2.transform.DOMoveX(0, _shakeDuration);
        cup3.transform.DOMoveX(6, _shakeDuration);
    }
}
