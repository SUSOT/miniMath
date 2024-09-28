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

    private int orderCount;
    private int maxTeamCount;


    [SerializeField]
    private TextMeshProUGUI mainText;
    [SerializeField]
    private TextMeshProUGUI currentOrderText;
    [SerializeField]
    private GameObject answerTimerText;

    [SerializeField]
    private GameObject correctChoosePanel;


    private CardSO currentOrder;


    private void Start()
    {
        playerCard = GameManager.Instance.playerSO;
        maxTeamCount = GameManager.Instance.teamCount;
        SolveStart();
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
        orderCount = 1;
        OrderChange();
        mainText.text = "";
    }

    private void GetProblem()
    {
        int rand = Random.Range(0, problemList.problemSO.Count);
        currentProblem = problemList.problemSO[rand];

        //문제 세팅
        mainText.text = "어떤 것이 정답일까요??";
    }

    private void AnswerStartAnimation()
    {

    }

    private void OrderChange()
    {
        currentOrder = playerCard[orderCount];
        currentOrderText.text = $"{currentOrder.teamName}팀의 차례!";
        answerTimerText.SetActive(true);
    }


    public void TimerEnd() //문제 선택 타이머 끝
    {
        answerTimerText.SetActive(false);
        WrongAnswer();
    }

    public void WrongAnswer()
    {
        print("오답");
        currentOrder.score -= 50;
        WrongAnswerAnimation();
        OrderEnd();
    }

    private void WrongAnswerAnimation()
    {

    }
    private void CorrectAnswerAnimation()
    {

    }

    public void CorrectAnswer()
    {
        print("정답");
        CorrectAnswerAnimation();
        correctChoosePanel.SetActive(true);
    }

    private void OrderEnd()
    {
        if (orderCount < maxTeamCount)
            orderCount++;
        else
            GameEnd();
        OrderChange();
    }

    private void GameEnd()
    {
        orderCount = 0;
        //"다음문제는 과연!!" 띄우기
        //다음 미니게임 뽑기
    }
}
