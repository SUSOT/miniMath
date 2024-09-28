using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTemaImage : MonoBehaviour
{
    [Header("본인 자식으로 있는 친구")]
    public Image teamIcon;

    public void SetTeamImage(Sprite sprite)
    {
        teamIcon.sprite = sprite;
    }
}
