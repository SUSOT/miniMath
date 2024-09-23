using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseScoreOrItem : MonoBehaviour{
    [SerializeField] private GameObject _scoreOrItemPanel;
    [SerializeField] private Button _falseButton;
    

    public void ActivePanel(){
        _scoreOrItemPanel.SetActive(true);
        _falseButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
