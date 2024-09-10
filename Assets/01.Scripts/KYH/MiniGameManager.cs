using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField]
    private MiniGameSoList miniGameList;//�̴ϰ����� ����ִ� ����Ʈ
    private MiniGameSO newMiniGame; //�������� �̾Ƽ� ���� �̴ϰ���

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
