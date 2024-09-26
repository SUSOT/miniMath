using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [Header("현재 참여한 팀수")]
    public int teamCount;

    [Header("현재 참여한 팀이름")]
    public string[] teamsName;


    [Header("현재 참여한 팀아이콘")]
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
