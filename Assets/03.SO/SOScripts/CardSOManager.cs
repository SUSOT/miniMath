using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSOManager : MonoBehaviour
{
    public CardSO cardSO;

    public void SaveCardSO()
    {
        cardSO.SaveToFile();
    }

    public void LoadCardSO()
    {
        cardSO.LoadFromFile();
    }
}
