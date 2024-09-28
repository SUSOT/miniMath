using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeamSignatureNumber : MonoBehaviour
{
    public CardSO cardSO;
    public TMP_InputField inputField;

    public void TeamsName()
    {
        print($"{cardSO.name}이름 바뀌는중");
        cardSO.teamName = inputField.text;
    }

    public void ValueChanged(string text) // string 매개변수는 기본으로 들어가는 매개변수이다
    {
        Debug.Log(text + " - 글자 입력 중");
    }
}
