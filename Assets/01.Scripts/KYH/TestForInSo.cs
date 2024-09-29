using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForInSO : MonoBehaviour
{
    public CardSO[] cardSO;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < cardSO.Length; i++)
            cardSO[i].teamName = $"실험적인이름{i}";
    }
}
