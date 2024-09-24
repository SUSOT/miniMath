using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamSettingManager : MonoBehaviour
{
    public GameObject[] playerCard;
    public Image[] image;

    private void Start()
    {
        for(int j =0; j< GameManager.Instance.teamCount - 1; j++)
        {
            playerCard[j].SetActive(true);
        }
        for(int i =0; i<GameManager.Instance.teamCount - 1; i++)
        {
            image[i].sprite = GameManager.Instance.teamsIcon[i];
        }
    }
}
