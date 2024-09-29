using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ItemFunctions : MonoBehaviour
{
    [SerializeField] private OrderManager _orderManager;
    [SerializeField] private List<int> AddScore = new List<int>();
    [SerializeField] private PlayableDirector _playableDirector;

    public void MyScoreUpMethod()
    {
        if(_playableDirector.duration < _playableDirector.time + 0.1f)
        {
            ItemManager.Instance.orderPlayer.score += AddScore[0];
            StartCoroutine(CorAnim());
        }
    }
    public void MyScoreDownMethod()
    {

        if (_playableDirector.duration < _playableDirector.time + 0.1f)
        {
            ItemManager.Instance.orderPlayer.score -= AddScore[1];
            _orderManager.ItemUsed();
        }
    }
    public void AnotherScoreUpMethod()
    {
        for (int i = 0; i < _orderManager.orderCount; i++)
        {
            if (i != _orderManager.orderCount)
                _orderManager.playerCard[i].score += AddScore[2];
        }
        _orderManager.ItemUsed();
    }
    public void AnotherScoreDownMethod()
    {
        for (int i = 0; i < _orderManager.orderCount; i++)
        {
            if (i != _orderManager.orderCount)
                _orderManager.playerCard[i].score -= AddScore[3];
        }
        _orderManager.ItemUsed();
    }
    public void EveryScoreUpMethod()
    {
        for (int i = 0; i < _orderManager.orderCount; i++)
        {
            _orderManager.playerCard[i].score += AddScore[4];
        }
        _orderManager.ItemUsed();
    }
    public void EveryScoreDownMethod()
    {
        for (int i = 0; i < _orderManager.orderCount; i++)
        {
            _orderManager.playerCard[i].score -= AddScore[5];
        }
        _orderManager.ItemUsed();
    }
    public void DoubleScoreMethod()
    {
        ItemManager.Instance.orderPlayer.score *= 2;//Á¡¼ö
        _orderManager.ItemUsed();
    }

    private void CorAnim()
    {

    }
}
