using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class EndSceneScript : MonoBehaviour
{
    public CardSO[] cardSOs;
    public Button nextButton;

    public TextMeshProUGUI text1st;
    public TextMeshProUGUI text2st;
    public TextMeshProUGUI text3st;
    private void Start()
    {
        DisplayWinner();
        nextButton.onClick.AddListener(OnNextButtonClick);
    }

    private void DisplayWinner()
    {
        System.Array.Sort(cardSOs, (card1, card2) => card1.score.CompareTo(card2.score));

        // 각 인덱스에 따라 텍스트 필드에 팀 이름을 할당
        if (cardSOs.Length > 0)
            text1st.text = cardSOs[0].teamName;

        if (cardSOs.Length > 1)
            text2st.text = cardSOs[1].teamName;

        if (cardSOs.Length > 2)
            text3st.text = cardSOs[2].teamName;

        //// 모든 CardSO를 순회하며 가장 높은 score를 가진 팀을 찾음
        //for (int i = 1; i < cardSOs.Length; i++)
        //{
        //    if (cardSOs[i].score > onest.score)
        //    {
        //        onest = cardSOs[i];
        //    }

        //    if (onest.score > secst.score)
        //    {
        //        secst = cardSOs[i - 1];
        //    }
        //}

    }

    private void OnNextButtonClick()
    {
        // 버튼 클릭 시 MenuScreen으로 이동
        SceneManager.LoadScene("MenuScreen");
    }
}
