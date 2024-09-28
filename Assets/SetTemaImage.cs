using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTemaImage : MonoBehaviour
{
    public CardSO cardSO;

    private void OnEnable()
    {
        GetComponentInChildren<Image>().sprite = cardSO.cardImage;
    }
}
