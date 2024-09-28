using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class OrderManager : MonoBehaviour
{
    private CardSO[] playerCard;

    [SerializeField]
    private ProblemList problemList;

    private ProblemSO currentProblem;

    private int teamCount;
    private int maxTeamCount;


    [SerializeField]
    private TextMeshProUGUI mainText;


    private void Start()
    {
        playerCard = GameManager.Instance.playerSO;
        maxTeamCount = GameManager.Instance.teamCount;
    }

    public void StartSolve()
    {
        GetProblem();
        TimerStart();//Âù¹ÎÀÌ
    }

    private void GetProblem()
    {
        int rand = Random.Range(0, problemList.problemSO.Count);
        currentProblem = problemList.problemSO[rand];
    }

    private void TimerStart()
    {

    }
}
