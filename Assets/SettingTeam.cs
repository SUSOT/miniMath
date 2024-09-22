using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingTeam : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int currentNum { get; private set; } = 1;
    private int prevNum = 1;
    public List<GameObject> teamCard = new List<GameObject>();


    private void Update()
    {
        Mathf.Clamp(currentNum,1,4);
    }

    public void PlusTeam()
    {
        if(!(currentNum > 3))
            currentNum++;
        SettingCount(currentNum);
    }

    public void MinusTeam()
    {
        if (!(currentNum < 2))
            currentNum--;
        SettingCount(currentNum);
    }

    public void SettingCount(int count)
    {
        if (prevNum > count)
            teamCard[count].SetActive(false);
        else
            teamCard[count-1].SetActive(true);
        text.text = $"{currentNum}";
        prevNum = count;
    }
}
