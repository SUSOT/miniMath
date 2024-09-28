using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerInfo")]
public class CardSO : ScriptableObject
{
    public Sprite cardImage;
    public string teamName;

    public int score;
    public bool isCorrectAnswer;
}
