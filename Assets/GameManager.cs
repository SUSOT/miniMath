using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [HideInInspector]
    public int teamCount;
    public string[] teamsName;
    public Dictionary<int,Sprite> teamsIcon = new Dictionary<int, Sprite>();


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
