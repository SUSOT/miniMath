using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActiveOpenButton : MonoBehaviour
{
    [SerializeField] private GameObject _sliderAndButton;
    [SerializeField] private Slider _slider;
    public event Action OpenBtnActive;
    private StartCutScene _cutScene;
    private int a = 1;
    public void CheckEndTimeLine()
    {
        _sliderAndButton.SetActive(true);
        _slider.gameObject.SetActive(true);
        OpenBtnActive?.Invoke();
    }
    private void Update()
    {
        if( _cutScene == null )
        {
            _cutScene = FindObjectOfType<StartCutScene>();
        }
        else if(_cutScene != null && a == 1)
        {
            _cutScene.OpenButtonEvent += CheckEndTimeLine;
            a++;
        }
    }
}
