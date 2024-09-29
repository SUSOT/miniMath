using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(menuName = "SO/PlayerInfo")]
public class CardSO : ScriptableObject
{
    public Sprite cardImage;
    public string teamName;

    public int score
    {
        get
        {
            return score; 
        }
        set
        {
            if(score <= 0)
            {
                score = 0;
            }
            else
            {
                score = value;
            }
        }
    }
    public bool isCorrectAnswer;
}
