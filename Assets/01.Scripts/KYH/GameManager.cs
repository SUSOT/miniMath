using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [Header("플레이어 1부터 순서대로 넣어야 정상작동 합니다!")]
    public CardSO[] playerSO;

    [HideInInspector]
    public int maxPlayerCount = 4;

    public Sprite[] teamsIcon;

    [Header("현재 참여한 팀수")]
    public int teamCount;

    public bool isTest;
    public Sprite testImage;
    public GameObject testForInSO;

    private void Awake()
    {
        teamsIcon = new Sprite[maxPlayerCount];

        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        if(isTest)
        {
            testForInSO.SetActive(true);
            for (int i = 0; i < teamCount; i++)
            {
                teamsIcon[i] = testImage;
            }
        }
    }

    public void TeamIconSet()
    {
        for(int i=0; i<teamCount; i++)
        {
            teamsIcon[i] = playerSO[i].cardImage;
        }
    }
}
