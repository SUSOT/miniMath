using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class RevealedTeamIconFade : MonoBehaviour
{
    [SerializeField]
    public Image blackPanel;

    public Image[] teamCard;

    [SerializeField]
    private GameObject[] playerCard;

    [SerializeField]
    private OrderManager orderManager;

    [SerializeField]
    private TextMeshProUGUI[] textMeshPros;

    [SerializeField] private CardSOManager playerScoreSave;


    private void Awake()
    {
        for (int j = 0; j <= GameManager.Instance.teamCount - 1; j++)
        {
            playerCard[j].SetActive(true);
            playerCard[j].GetComponentInChildren<SetTemaImage>()
                .SetTeamImage(GameManager.Instance.teamsIcon[j]);
        }
    }

    private void OnEnable()
    {
        for(int i = 0; i< GameManager.Instance.teamCount - 1; i++)
        {
            textMeshPros[i].SetText($"{orderManager.playerCard[i].score}Á¡");
        }    
    }

    public void FadeIn()
    {
        blackPanel.DOFade(1, 1);
        for (int i = 0; i < teamCard.Length; i++)
        {
            teamCard[i].DOFade(1,1);
        }
    }
    public void FadeOut()
    {
        blackPanel.DOFade(0, 1);
        for (int i = 0; i < teamCard.Length; i++)
        {
            teamCard[i].DOFade(0, 1);
        }
    }
}
