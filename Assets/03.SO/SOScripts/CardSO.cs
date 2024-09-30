using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(menuName = "SO/PlayerInfo")]
public class CardSO : ScriptableObject
{
    public Sprite cardImage;
    public string teamName;

    private int _score;

    public int score
    {
        get
        {
            return _score; 
        }
        set
        {
            if(_score <= 0)
            {
                _score = 0;
            }
            else
            {
                _score = value;
            }
        }
    }
    public bool isCorrectAnswer;
}
