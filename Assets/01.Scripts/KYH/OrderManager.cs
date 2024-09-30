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

    public int orderCount { get; private set; }
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

    public List<RectTransform> randAnswerButtonPos = new List<RectTransform>();

    public GameObject correctAnswer;
    public GameObject wrongAnswer;
    public GameObject wrongAnswer2;

    [HideInInspector]
    public PlayableDirector answerRevealed;

    public GameObject revealedTeamIcon;

    [SerializeField]
    private GameObject[] answerButton;

    private OpenChestTimeLine chestTimeLine;


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
        RandomProblemGacha();
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
        if (currentProblem.CorrectAnswer.Length < 1 || currentProblem.firstWrongAnswer.Length < 1 || currentProblem.secondWrongAnswer.Length < 1 || currentProblem.whatIsProblem.Length < 1)
        {
            RandomProblemGacha();
        }

        //문제 세팅
        SettingProblem();

        mainText.text = currentProblem.whatIsProblem;
    }

    private void RandomProblemGacha()
    {
        int rand = Random.Range(0, problemList.problemSO.Count);
        currentProblem = problemList.problemSO[rand];
        GetProblem();
    }

    private void SettingProblem()
    {
        for (int j = 0; j < answerButton.Length; j++)
        {
            answerButton[j].transform.SetParent(null);
        }

        correctAnswer.GetComponentInChildren<TextMeshProUGUI>().text = currentProblem.CorrectAnswer;
        wrongAnswer.GetComponentInChildren<TextMeshProUGUI>().text = currentProblem.firstWrongAnswer;
        wrongAnswer2.GetComponentInChildren<TextMeshProUGUI>().text = currentProblem.secondWrongAnswer;
        GameObject.Find("ItemChooseCanvas").transform.Find("TEXDraw").GetComponent<SetImage>().GetTexture(currentProblem.whatIsProblem);
        GameObject.Find("ItemChooseCanvas").transform.Find("TEXDraw").GetComponent<SetImage>().GetTexture(currentProblem.CorrectAnswer);
        GameObject.Find("ItemChooseCanvas").transform.Find("TEXDraw").GetComponent<SetImage>().GetTexture(currentProblem.firstWrongAnswer);
        GameObject.Find("ItemChooseCanvas").transform.Find("TEXDraw").GetComponent<SetImage>().GetTexture(currentProblem.secondWrongAnswer);

        RandomShuffle.GetRandomShuffleList(randAnswerButtonPos);

        for (int i = 0; i < randAnswerButtonPos.Count; i++)
        {
            answerButton[i].transform.position = randAnswerButtonPos[i].position;
            answerButton[i].transform.SetParent(randAnswerButtonPos[i]);
        }

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
        chestTimeLine = FindAnyObjectByType<OpenChestTimeLine>();
        chestTimeLine.TimeLine();
        StartCoroutine(RevealedRoutine());
    }


    private IEnumerator RevealedRoutine()
    {
        if (answerRevealed != null)
        {
            answerRevealed.Play();
            yield return new WaitForSeconds(5f);
            answerRevealed.Stop();
            revealedTeamIcon.SetActive(true);
            revealedTeamIcon.GetComponent<RevealedTeamIconFade>().FadeIn();
            yield return new WaitForSeconds(2);
            AnswerRightTeams();
        }
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
        chestTimeLine = null;
        
    }
}
