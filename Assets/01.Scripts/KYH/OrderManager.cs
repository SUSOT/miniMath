using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Random = UnityEngine.Random;
using TMPro;
using System.Linq;

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

    private void SettingProblem() //��� ��¥ħ �ð� ���� ����
    {
        for(int j =0; j<answerButton.Length; j++)
        {
            answerButton[j].transform.SetParent(null);
        }

        correctAnswer.GetComponentInChildren<TextMeshProUGUI>().text = currentProblem.CorrectAnswer;
        wrongAnswer.GetComponentInChildren<TextMeshProUGUI>().text = currentProblem.firstWrongAnswer;
        wrongAnswer2.GetComponentInChildren<TextMeshProUGUI>().text = currentProblem.secondWrongAnswer;

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
        currentOrderText.text = "������!!";
        answerTimerText.GetComponent<AnswerTimerCountDown>().currentTime = answerTimerText.GetComponent<AnswerTimerCountDown>().timeLimit;
        answerTimerText.SetActive(false);
        correctAnswer.SetActive(false);
        wrongAnswer.SetActive(false);
        wrongAnswer2.SetActive(false);
        chestTimeLine = FindAnyObjectByType<OpenChestTimeLine>();
        chestTimeLine.TimeLine();
        StartCoroutine(RevealedRoutine());

        //"���������� ����!!" ����
        //���� �̴ϰ��� �̱�
    }


    private IEnumerator RevealedRoutine()
    {
        if(answerRevealed != null)
        {
            answerRevealed.Play();
            yield return new WaitForSeconds(5f);
            print("������� ��");
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
                print($"{playerCard[i].teamName}�� ����");
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
        print("���ӳ�");
        chestTimeLine = null;
    }
}
