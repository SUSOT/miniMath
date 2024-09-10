using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MiniGameSetup : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera solveMathProblemCamera;

    public void StartGame()
    {
        solveMathProblemCamera.Priority = 2;

        MiniGameSetting[] game = GetComponentsInChildren<MiniGameSetting>();

        foreach (MiniGameSetting miniGameSetting in game)
        {
            print("½ÇÇàµÊ");
            miniGameSetting.Enter();
        }
    }
}
