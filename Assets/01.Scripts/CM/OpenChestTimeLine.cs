using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class OpenChestTimeLine : MonoBehaviour
{
    public PlayableDirector currentCutScene;

    public PlayableAsset leftAnswer;
    public PlayableAsset rightAnswer;
    public PlayableAsset middleAnswer;

    private Correct correct;

    private int pointPos;

    private List<GameObject> answerPoint = new List<GameObject>();

    public void TimeLine()
    {
        OrderManager orderManager = FindAnyObjectByType<OrderManager>();
        foreach (Transform answerPoints in orderManager.randAnswerButtonPos)
        {
            answerPoint.Add(answerPoints.gameObject);
        }

        for (int i = 0; i < answerPoint.Count; i++)
        {
            correct = answerPoint[i]?.transform.GetChild(0).GetComponent<Correct>();
            print(correct);
            if (correct != null)
            {
                pointPos = answerPoint[i].GetComponent<ProblemPoint>().point;
            }
            else
                print(answerPoint[i] + "¾ê´Â ¾ø´Ù");
        }
        currentCutScene = GetComponent<PlayableDirector>();

        if (pointPos == 1)
            currentCutScene.playableAsset = middleAnswer;
        else if (pointPos == 2)
            currentCutScene.playableAsset = leftAnswer;
        else if (pointPos == 3)
            currentCutScene.playableAsset = rightAnswer;


        orderManager.answerRevealed = currentCutScene;
    
    }

    //private void Start()
    //{
    //    _active = FindObjectOfType<ActiveOpenButton>();
    //    Debug.Log(_active);
    //    _active.OpenBtnActive += FindButton;
    //}
    //public void FindButton()
    //{
    //    _openBtn = GameObject.Find("SliderAndOpenBtn/OpenBtn").GetComponent<Button>();
    //    _openBtn.onClick.AddListener(StartCutScene);
    //}

    //public void StartCutScene()
    //{
    //    cutScene.Play();
    //}
}
