using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTemaImage : MonoBehaviour
{
    [Header("���� �ڽ����� �ִ� ģ��")]
    public Image teamIcon;

    public void SetTeamImage(Sprite sprite)
    {
        teamIcon.sprite = sprite;
    }
}
