using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI text;

    [SerializeField] private int minimum = 0;
    [SerializeField]private int maximum = 0;

    public int currentNum { get; private set; }
    private int previousNum = 1;

    private void Start()
    {
        currentNum = minimum;
        text.text = $"{currentNum}";
    }

    private void Update()
    {
        Mathf.Clamp(currentNum, minimum, maximum);
    }

    public void PlusNum()
    {
        if (!(currentNum >= maximum))
            currentNum++;
        SettingCount(currentNum);
    }

    public void MinunNum()
    {
        if (!(currentNum <= minimum))
            currentNum--;
        SettingCount(currentNum);
    }

    public void SettingCount(int count)
    {
        text.text = $"{currentNum}";
        previousNum = count;
        GameManager.Instance.problemCount = currentNum;
    }
}
