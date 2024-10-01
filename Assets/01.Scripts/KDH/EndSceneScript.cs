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

        // �� �ε����� ���� �ؽ�Ʈ �ʵ忡 �� �̸��� �Ҵ�
        if (cardSOs.Length > 0)
            text1st.text = cardSOs[0].teamName;

        if (cardSOs.Length > 1)
            text2st.text = cardSOs[1].teamName;

        if (cardSOs.Length > 2)
            text3st.text = cardSOs[2].teamName;

        //// ��� CardSO�� ��ȸ�ϸ� ���� ���� score�� ���� ���� ã��
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
        // ��ư Ŭ�� �� MenuScreen���� �̵�
        SceneManager.LoadScene("MenuScreen");
    }
}
