using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class OpenChestTimeLine : MonoBehaviour{
    public PlayableDirector cutScene;
    private Button _openBtn;
    private ActiveOpenButton _active;

    private void Start()
    {
        _active = FindObjectOfType<ActiveOpenButton>();
        Debug.Log(_active);
        _active.OpenBtnActive += FindButton;
    }
    public void FindButton()
    {
        _openBtn = GameObject.Find("SliderAndOpenBtn/OpenBtn").GetComponent<Button>();
        _openBtn.onClick.AddListener(StartCutScene);
    }

    public void StartCutScene()
    {
        cutScene.Play();
    }
}
