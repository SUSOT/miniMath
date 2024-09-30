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

        // 모든 CardSO를 순회하며 가장 높은 score를 가진 팀을 찾음
        for (int i = 1; i < cardSOs.Length; i++)
        {
            if (cardSOs[i].score > winningCard.score)
            {
                winningCard = cardSOs[i];
            }
        }

        // 우승 팀 이름을 TMP_Text에 표시
        winnerText.text = $"{winningCard.teamName} \n 승리";
    }

    private void OnNextButtonClick()
    {
        // 버튼 클릭 시 MenuScreen으로 이동
        SceneManager.LoadScene("MenuScreen");
    }
}
