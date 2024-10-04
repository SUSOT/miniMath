using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour
{
    public CardSO[] cardSOs;
    public Button nextButton;

    public TextMeshProUGUI text1st;
    public TextMeshProUGUI text2nd;
    public TextMeshProUGUI text3rd;

    private void Start()
    {
        nextButton.onClick.AddListener(OnNextButtonClick);
        DisplayWinner();
    }

    private void DisplayWinner()
    {
        System.Array.Sort(cardSOs, (card1, card2) => card2.score.CompareTo(card1.score));

        if (cardSOs.Length > 0)
            text1st.text = cardSOs[0].teamName;

        if (cardSOs.Length > 1)
            text2nd.text = cardSOs[1].teamName;

        if (cardSOs.Length > 2)
            text3rd.text = cardSOs[2].teamName;
    }

    private void OnNextButtonClick()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}