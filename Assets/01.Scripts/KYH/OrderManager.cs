using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
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

    [SerializeField]
    private GameObject teamIcon;

    private CardSO currentOrder;

    public List<Transform> randAnswerButtonPos = new List<Transform>();

    public GameObject correctAnswer;
    public GameObject wrongAnswer;
    public GameObject wrongAnswer2;

    [HideInInspector]
    public PlayableDirector answerRevealed;

    public GameObject revealedTeamIcon;

    private void Awake()
    {
        playerCard = GameManager.Instance.playerSO;
        maxTeamCount = GameManager.Instance.teamCount;
        for(int i =0; i<playerCard.Length; i++)
        {
            playerCard[i].isCorrectAnswer = false;
            playerCard[i].score = 0;
        }
    }

    
    public void SolveStart()
    {
        GetProblem();
        countDownTimer.gameObject.SetActive(true);
        countDownTimer.TimerStart();
    }

    public void SolveEnd() // Ÿ�̸� ������
    {
        teamIcon.SetActive(false);
        countDownTimer.gameObject.SetActive(false);
        AnswerStartAnimation();
        correctAnswer.SetActive(true);
        wrongAnswer.SetActive(true);
        wrongAnswer2.SetActive(true);
        orderCount = 0;
        OrderChange();
        mainText.text = "";
    }

    private void GetProblem()
    {
        int rand = Random.Range(0, problemList.problemSO.Count);
        currentProblem = problemList.problemSO[rand];

        //���� ����
        SettingProblem();

        mainText.text = currentProblem.whatIsProblem;
    }

    private void SettingProblem() //��� ¥ħ
    {
        correctAnswer.GetComponentInChildren<TextMeshProUGUI>().text = currentProblem.CorrectAnswer;
        wrongAnswer.GetComponentInChildren<TextMeshProUGUI>().text = currentProblem.firstWrongAnswer;
        wrongAnswer2.GetComponentInChildren<TextMeshProUGUI>().text = currentProblem.secondWrongAnswer;

        //Transform[] transforms = { correctAnswer.transform, wrongAnswer.transform, wrongAnswer2.transform };

    }

    private void AnswerStartAnimation()
    {

    }

    private void OrderChange()
    {
        currentOrder = playerCard[orderCount];
        currentOrderText.text = $"{currentOrder.teamName}���� ����!";
        answerTimerText.SetActive(true);
        answerTimerText.GetComponent<AnswerTimerCountDown>().currentTime = answerTimerText.GetComponent<AnswerTimerCountDown>().timeLimit;
    }


    public void TimerEnd() //���� ���� Ÿ�̸� ��
    {
        answerTimerText.SetActive(false);
        WrongAnswer();
    }

    public void WrongAnswer()
    {
        print("����");
        currentOrder.score -= 50;
        currentOrder.isCorrectAnswer = false;
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
        print("����");
        CorrectAnswerAnimation();
        correctChoosePanel.SetActive(true);
        currentOrder.isCorrectAnswer = true;
        OrderEnd();
    }

    private void OrderEnd()
    {
        if (orderCount < maxTeamCount-1)
        {
            orderCount++;
            OrderChange();
        }
        else
            GameEnd();
    }

    private void GameEnd()
    {
        orderCount = 0;
        currentOrderText.text = "������!!";
        answerTimerText.GetComponent<AnswerTimerCountDown>().currentTime = answerTimerText.GetComponent<AnswerTimerCountDown>().timeLimit;
        answerTimerText.SetActive(false);
        correctAnswer.SetActive(false);
        wrongAnswer.SetActive(false);
        wrongAnswer2.SetActive(false);
        StartCoroutine(RevealedRoutine());
        //"���������� ����!!" ����
        //���� �̴ϰ��� �̱�
    }


    private IEnumerator RevealedRoutine()
    {
        yield return new WaitForSeconds(3);
        answerRevealed.Play();
        if (answerRevealed.duration < answerRevealed.time + 0.1f)
        {
            answerRevealed.Stop();
            revealedTeamIcon.SetActive(true);
            revealedTeamIcon.GetComponent<RevealedTeamIconFade>().FadeIn();
        }
        yield return new WaitForSeconds(2);
        AnswerRightTeams();
    }

    private void AnswerRightTeams()
    {
        for (int i = 0; i < playerCard.Length; i++)
        {
            if(playerCard[i].isCorrectAnswer)

        }
    }
}
