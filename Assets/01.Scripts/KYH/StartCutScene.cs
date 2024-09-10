using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartCutScene : MonoBehaviour
{
    private PlayableDirector playableDirector;

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
        }
    }
}
