using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFunctions : MonoBehaviour
{

    public void MyScoreUpMethod()
    {
        ItemManager.Instance.orderPlayer.score += 500;//점수
        //orderManager.ItemUsed();//끝
    }
    public void MyScoreDownMethod()
    {
        ItemManager.Instance.orderPlayer.score += 500;//점수
        //orderManager.ItemUsed();
    }
    public void AnotherScoreUpMethod()
    {
        ItemManager.Instance.orderPlayer.score += 500;//점수
        //orderManager.ItemUsed();
    }
    public void AnotherScoreDownMethod()
    {
        ItemManager.Instance.orderPlayer.score += 500;//점수
        //orderManager.ItemUsed();
    }
    public void EveryScoreUpMethod()
    {
        ItemManager.Instance.orderPlayer.score += 500;//점수
        //orderManager.ItemUsed();
    }
    public void EveryScoreDownMethod()
    {
        ItemManager.Instance.orderPlayer.score += 500;//점수
        //orderManager.ItemUsed();
    }
    public void DoubleScoreMethod()
    {
        ItemManager.Instance.orderPlayer.score += 500;//점수
        //orderManager.ItemUsed();
    }
}
