using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [Header("���� ������ ����")]
    public int teamCount;

    [Header("���� ������ ���̸�")]
    public string[] teamsName;


    [Header("���� ������ ��������")]
    public List<Sprite> teamIcon = new List<Sprite>();


    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
