using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField]
    private MiniGameSoList miniGameList;//미니게임이 들어있는 리스트
    private MiniGameSO newMiniGame; //랜덤으로 뽑아서 나온 미니게임

    private GameObject gameSequencing = null;

    private void Start()
    {
        StartMiniGame();
    }

    public void StartMiniGame()
    {
        if (gameSequencing != null)
            gameSequencing.SetActive(false);

        int randNum = Random.Range(0, miniGameList.randomMiniGameList.Count - 1);
        newMiniGame = miniGameList.randomMiniGameList[randNum];
        print(AudioManager.Instance);
        AudioManager.Instance.PlaySound2D(newMiniGame.backGroundBGM.name);
        gameSequencing = newMiniGame.miniGameSituationPrefab;

        Instantiate(gameSequencing);
        gameSequencing.SetActive(true);
        gameSequencing = null;
    }
}
