using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ItemFunctions : MonoBehaviour
{
    [SerializeField] private OrderManager _orderManager;
    [SerializeField] private List<int> AddScore = new List<int>();
    [SerializeField] private List<PlayableDirector> _playableDirector = new List<PlayableDirector>();
    [SerializeField] private MoveItemScene _moveItemScene;
    [SerializeField] private ItemText _itemText;

    public void MyScoreUpMethod()
    {
        if (_playableDirector[_moveItemScene.rand].duration <= _playableDirector[_moveItemScene.rand].time)
        {
            ItemManager.Instance.orderPlayer.score += AddScore[0];
            StartCoroutine(CorAnim());
        }
    }
    public void MyScoreDownMethod()
    {

        if (_playableDirector[_moveItemScene.rand].duration <= _playableDirector[_moveItemScene.rand].time)
        {
            ItemManager.Instance.orderPlayer.score -= AddScore[1];
            StartCoroutine(CorAnim());
        }
    }
    public void AnotherScoreUpMethod()
    {
        if (_playableDirector[_moveItemScene.rand].duration <= _playableDirector[_moveItemScene.rand].time)
        {
            for (int i = 0; i < _orderManager.orderCount; i++)
            {
                if (i != _orderManager.orderCount)
                    _orderManager.playerCard[i].score += AddScore[2];
            }
            StartCoroutine(CorAnim());
        }
    }
    public void AnotherScoreDownMethod()
    {
        if (_playableDirector[_moveItemScene.rand].duration <= _playableDirector[_moveItemScene.rand].time)
        {

            for (int i = 0; i < _orderManager.orderCount; i++)
            {
                if (i != _orderManager.orderCount)
                    _orderManager.playerCard[i].score -= AddScore[3];
            }
            StartCoroutine(CorAnim());
        }
    }
    public void EveryScoreUpMethod()
    {
        if (_playableDirector[_moveItemScene.rand].duration <= _playableDirector[_moveItemScene.rand].time)
        {
            for (int i = 0; i < _orderManager.orderCount; i++)
            {
                _orderManager.playerCard[i].score += AddScore[4];
            }
            StartCoroutine(CorAnim());
        }
    }
    public void EveryScoreDownMethod()
    {
        if (_playableDirector[_moveItemScene.rand].duration <= _playableDirector[_moveItemScene.rand].time)
        {
            for (int i = 0; i < _orderManager.orderCount; i++)
            {
                _orderManager.playerCard[i].score -= AddScore[5];
            }
            StartCoroutine(CorAnim());
        }
    }
    public void DoubleScoreMethod()
    {
        if (_playableDirector[_moveItemScene.rand].duration <= _playableDirector[_moveItemScene.rand].time)
        {
            ItemManager.Instance.orderPlayer.score *= 2;
            StartCoroutine(CorAnim());
        }
    }

    private IEnumerator CorAnim()
    {
        _itemText.StartCor();
        yield return new WaitForSeconds(1f);
        _orderManager.ItemUsed();
    }

    private void Update()
    {
        Debug.Log(_playableDirector[_moveItemScene.rand].duration < _playableDirector[_moveItemScene.rand].time + 0.01f);
    }
}
