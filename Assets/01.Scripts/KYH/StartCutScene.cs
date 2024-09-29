using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartCutScene : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector playableDirector;
    public event Action OpenButtonEvent;


    private void OnEnable()
    {
        playableDirector.Play();
    }

    private void Update()
    {
        if (playableDirector.duration < playableDirector.time + 0.1f)
        {
            print("����Ǯ�� ����");
            playableDirector.Stop();
            GetComponent<MiniGameSetup>().StartGame();
            OpenButtonEvent?.Invoke();
            FindAnyObjectByType<OrderManager>().SolveStart();
        }
    }
}
