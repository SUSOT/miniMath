using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance = null;

    public List<GameObject> ItemList = new List<GameObject>();

    public List<CardSO> revealedPlayers = new List<CardSO>();

    public int randItem;

    public CardSO orderPlayer;

    [HideInInspector]
    public int orderNum = 0;

    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public static ItemManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void SetOrderTeams()
    {
        orderPlayer = revealedPlayers[orderNum];
        text.gameObject.SetActive(true);
        text.text = $"{orderPlayer.teamName}ÆÀ Â÷·ÊÀÔ´Ï´Ù!";
    }
}
