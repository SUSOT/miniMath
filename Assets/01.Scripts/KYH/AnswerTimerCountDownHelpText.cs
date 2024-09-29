using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerTimerCountDownHelpText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    // Update is called once per frame
    private void Start()
    {
        textMeshPro.TextUpDownMove(58f,Color.white,2f,TextStyle.UI|TextStyle.Moving);
    }
}
