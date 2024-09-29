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

    public CardSO[] playerCard;

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
        for (int i = 0; i < playerCard.Length; i++)
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

    public void SolveEnd() // 타이머 끝나면
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

        //문제 세팅
        SettingProblem();

        mainText.text = currentProblem.whatIsProblem;
    }

    private void SettingProblem() //얘는 짜침
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
        currentOrderText.text = $"{currentOrder.teamName}팀의 차례!";
        answerTimerText.SetActive(true);
        answerTimerText.GetComponent<AnswerTimerCountDown>().currentTime = answerTimerText.GetComponent<AnswerTimerCountDown>().timeLimit;
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
        print("정답");
        CorrectAnswerAnimation();
        currentOrder.isCorrectAnswer = true;
        OrderEnd();
    }

    private void OrderEnd()
    {
        if (orderCount < maxTeamCount - 1)
        {
            orderCount++;
            OrderChange();
        }
        else
            AnswerRevealed();
    }

    private void AnswerRevealed()
    {
        orderCount = 0;
        currentOrderText.text = "정답은!!";
        answerTimerText.GetComponent<AnswerTimerCountDown>().currentTime = answerTimerText.GetComponent<AnswerTimerCountDown>().timeLimit;
        answerTimerText.SetActive(false);
        correctAnswer.SetActive(false);
        wrongAnswer.SetActive(false);
        wrongAnswer2.SetActive(false);
        StartCoroutine(RevealedRoutine());
        //"다음문제는 과연!!" 띄우기
        //다음 미니게임 뽑기
    }


    private IEnumerator RevealedRoutine()
    {
        answerRevealed.Play();
        yield return new WaitForSeconds((float)answerRevealed.duration);
        print("정답공개 끝");
        answerRevealed.Stop();
        revealedTeamIcon.SetActive(true);
        revealedTeamIcon.GetComponent<RevealedTeamIconFade>().FadeIn();
        yield return new WaitForSeconds(2);
        AnswerRightTeams();
    }

    private void AnswerRightTeams()
    {
        currentOrderText.text = "";
        for (int i = 0; i < playerCard.Length; i++)
        {
            if (playerCard[i].isCorrectAnswer)
            {
                print($"{playerCard[i].teamName}팀 정답");
                ItemManager.Instance.revealedPlayers.Add(playerCard[i]);
            }
        }
        RevealedTemasChooseTime();
        ItemManager.Instance.orderNum = 0;
    }

    private void RevealedTemasChooseTime()
    {
        if(ItemManager.Instance.orderNum >= ItemManager.Instance.revealedPlayers.Count -1)
        {
            GameEnd();
        }
        else
        {
            correctChoosePanel.SetActive(true);
            ItemManager.Instance.SetOrderTeams();
        }
    }

    public void ScoreSelect()
    {
        correctChoosePanel.SetActive(false);
        ItemManager.Instance.orderPlayer.score += 200;
        ItemManager.Instance.orderNum++;
        ItemManager.Instance.SetOrderTeams();
        ScoreUp();
    }

    private void ScoreUp()
    {
        RevealedTemasChooseTime();
    }

    public void ItemSelect()
    {
        correctChoosePanel.SetActive(false);
        ItemManager.instance.randItem = Random.Range(0, ItemManager.instance.ItemList.Count);
        revealedTeamIcon.SetActive(false);
        ItemManager.instance.ItemList[ItemManager.instance.randItem].SetActive(true);
        ItemManager.Instance.orderNum++;
        ItemManager.Instance.SetOrderTeams();
    }

    public void ItemUsed()
    {
        RevealedTemasChooseTime();
    }

    private void GameEnd()
    {
        print("게임끝");
    }
}
