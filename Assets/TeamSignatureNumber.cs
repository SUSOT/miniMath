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
        print($"{cardSO.name}�̸� �ٲ����");
        cardSO.teamName = inputField.text;
    }

    public void ValueChanged(string text) // string �Ű������� �⺻���� ���� �Ű������̴�
    {
        Debug.Log(text + " - ���� �Է� ��");
    }
}
