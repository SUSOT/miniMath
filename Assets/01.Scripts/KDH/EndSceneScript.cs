using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour
{
    public CardSO[] cardSOs;
    public TMP_Text winnerText; 
    public Button nextButton; 
    private void Start()
    {
        DisplayWinner();
        nextButton.onClick.AddListener(OnNextButtonClick);
    }

    private void DisplayWinner()
    {
        CardSO winningCard = cardSOs[0]; 

        // ��� CardSO�� ��ȸ�ϸ� ���� ���� score�� ���� ���� ã��
        for (int i = 1; i < cardSOs.Length; i++)
        {
            if (cardSOs[i].score > winningCard.score)
            {
                winningCard = cardSOs[i];
            }
        }

        // ��� �� �̸��� TMP_Text�� ǥ��
        winnerText.text = $"{winningCard.teamName} \n �¸�";
    }

    private void OnNextButtonClick()
    {
        // ��ư Ŭ�� �� MenuScreen���� �̵�
        SceneManager.LoadScene("MenuScreen");
    }
}
