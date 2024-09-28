using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartCutScene : MonoBehaviour
{
    private PlayableDirector playableDirector;
    public event Action OpenButtonEvent;

    private void OnEnable()
    {
        playableDirector = GetComponentInChildren<PlayableDirector>();
        playableDirector.Play();
    }

    private void Update()
    {
        if (playableDirector.duration < playableDirector.time + 0.1f)
        {
            playableDirector.Stop();
            GetComponent<MiniGameSetup>().StartGame();
            OpenButtonEvent?.Invoke();
        }
    }
}
