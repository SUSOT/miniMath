using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpenChestTimeLine : MonoBehaviour{
    public PlayableDirector cutScene;

    public void StartCutScene(){
        cutScene.Play();
    }
}
