using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameSetup : MonoBehaviour
{
    private void StartGame()
    {
        MiniGameSetting[] game = GetComponentsInChildren<MiniGameSetting>();

        foreach (MiniGameSetting miniGameSetting in game)
        {
            miniGameSetting.Enter();
        }
    }
}
