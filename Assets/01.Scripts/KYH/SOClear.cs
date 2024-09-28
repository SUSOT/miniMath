using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOClear : MonoBehaviour
{
    public CardSO[] cardSO;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < cardSO.Length; i++)
            cardSO[i].teamName = "";
    }
}
