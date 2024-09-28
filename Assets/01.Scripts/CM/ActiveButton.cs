using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ActiveButton : MonoBehaviour{
    [FormerlySerializedAs("ButtonParents")] [SerializeField] private GameObject _buttonParents;
    [SerializeField] private GameObject _sliderAndBtn;

    public void Activebutton(){
        _buttonParents.SetActive(true);
        _sliderAndBtn.SetActive(false);
    }
}
