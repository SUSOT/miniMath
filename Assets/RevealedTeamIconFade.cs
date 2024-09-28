using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RevealedTeamIconFade : MonoBehaviour
{
    [SerializeField]
    public Image blackPanel;

    [SerializeField]
    public Image[] teamCard;

    public void FadeIn()
    {
        blackPanel.DOFade(1, 1);
        for (int i = 0; i < teamCard.Length; i++)
        {
            teamCard[i].DOFade(1,1);
        }
    }
}
