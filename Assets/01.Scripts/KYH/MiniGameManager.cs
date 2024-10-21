using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField]
    private MiniGameSoList miniGameList;//�̴ϰ����� ����ִ� ����Ʈ
    private MiniGameSO newMiniGame; //�������� �̾Ƽ� ���� �̴ϰ���

    public GameObject gameSequencing = null;
    public GameObject currentSequencing;

    private void Start()
    {
        StartMiniGame();
    }

    public void StartMiniGame()
    {
        int randNum = Random.Range(0, miniGameList.randomMiniGameList.Count);
        newMiniGame = miniGameList.randomMiniGameList[randNum];
        print(AudioManager.Instance);
        AudioManager.Instance.PlaySound2D(newMiniGame.backGroundBGM.name);
        gameSequencing = newMiniGame.miniGameSituationPrefab;

        currentSequencing = Instantiate(gameSequencing);
        gameSequencing.SetActive(true);
    }
}
