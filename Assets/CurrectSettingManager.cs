using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrectSettingManager : MonoBehaviour
{
    public GameObject[] playerCard;
    public GameObject[] revealedIcon;

    private void Start()
    {
        for (int j = 0; j <= GameManager.Instance.teamCount - 1; j++)
        {
            playerCard[j].SetActive(true);
            playerCard[j].GetComponentInChildren<SetTemaImage>()
                .SetTeamImage(GameManager.Instance.teamsIcon[j]);
        }
    }

    public void RevealedIcon()
    {
        for (int j = 0; j <= GameManager.Instance.teamCount - 1; j++)
        {
            revealedIcon[j].SetActive(true);
            revealedIcon[j].GetComponentInChildren<SetTemaImage>()
                .SetTeamImage(GameManager.Instance.teamsIcon[j]);
        }
    }
}
