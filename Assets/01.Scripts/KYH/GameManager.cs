using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [Header("�÷��̾� 1���� ������� �־�� �����۵� �մϴ�!")]
    public CardSO[] playerSO;

    [HideInInspector]
    public int maxPlayerCount = 4;

    public Sprite[] teamsIcon;

    [Header("���� ������ ����")]
    public int teamCount;

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

    public void TeamIconSet()
    {
        for(int i=0; i<teamCount; i++)
        {
            teamsIcon[i] = playerSO[i].cardImage;
        }
    }
}
