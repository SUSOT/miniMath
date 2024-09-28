using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class OrderManager : MonoBehaviour
{
    [SerializeField]
    private CountDownTimer countDownTimer;

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
        StartSolve();
    }

    public void SolveStart()
    {
        GetProblem();
        countDownTimer.gameObject.SetActive(true);
        countDownTimer.TimerStart();
    }

    public void SolveEnd() // 타이머 끝나면
    {
        countDownTimer.gameObject.SetActive(false);
        AnswerStartAnimation();
        teamCount = 1;
        OrderChange();
    }

    private void AnswerStartAnimation()
    {

    }

    private void OrderChange()
    {
        currentProblem = playerCard[teamCount];
        { 팀이름 텍스트 바꿔주기}
        선택 차례
        문제 선택 타이머 시작
    }

    private void GetProblem()
    {
        int rand = Random.Range(0, problemList.problemSO.Count);
        currentProblem = problemList.problemSO[rand];
        //문제 세팅
        mainText.text = "어떤 것이 정답일까요??";
    }

    private void TimerEnd()
    {
        WrongAnswer();
    }

    public void WrongAnswer()
    {

    }

    public void CorrectAnswer()
    {

    }
}
