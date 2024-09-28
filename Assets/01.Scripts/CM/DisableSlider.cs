using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableSlider : MonoBehaviour
{
    [SerializeField] private Slider _me;
    [SerializeField] private float _value;

    void OnEnable()
    {
        _me.value = _value;
    }
}
