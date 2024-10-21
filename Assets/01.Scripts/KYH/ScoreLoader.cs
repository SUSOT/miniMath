using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLoader : MonoBehaviour
{
    public CardSO cardSO;

    private void Awake()
    {
        cardSO.SaveToFile();
    }
}