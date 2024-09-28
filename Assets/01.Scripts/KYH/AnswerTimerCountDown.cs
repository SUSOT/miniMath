using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerTimerCountDown : MonoBehaviour
{
    [Header("제한시간")]
    [SerializeField]
    private float timeLimit;

    private float currentTime;

    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    private OrderManager orderManager;

    void Start()
    {
        currentTime = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (0 > currentTime)
        {
            orderManager.TimerEnd();
        }
        else
        {
            currentTime -= Time.deltaTime;
            timerText.text = $"{currentTime.ToString().Substring(0,2)}";
        }
    }
}
