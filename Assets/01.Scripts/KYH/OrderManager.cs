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

    public void SolveEnd() // Ÿ�̸� ������
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
        { ���̸� �ؽ�Ʈ �ٲ��ֱ�}
        ���� ����
        ���� ���� Ÿ�̸� ����
    }

    private void GetProblem()
    {
        int rand = Random.Range(0, problemList.problemSO.Count);
        currentProblem = problemList.problemSO[rand];
        //���� ����
        mainText.text = "� ���� �����ϱ��??";
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
