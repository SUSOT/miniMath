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
    [SerializeField] private CardSOManager playerScoreSave;

    public void MyScoreUpMethod()
    {
        ItemManager.Instance.orderPlayer.score += AddScore[0];
        playerScoreSave.cardSO = ItemManager.Instance.orderPlayer;
        playerScoreSave.SaveCardSO();
        playerScoreSave.cardSO = null;
        StartCoroutine(CorAnim());
    }
    public void MyScoreDownMethod()
    {

        ItemManager.Instance.orderPlayer.score -= AddScore[1];
        playerScoreSave.cardSO = ItemManager.Instance.orderPlayer;
        playerScoreSave.SaveCardSO();
        playerScoreSave.cardSO = null;
        StartCoroutine(CorAnim());
    }
    public void AnotherScoreUpMethod()
    {
        for (int i = 0; i < _orderManager.playerCard.Length; i++)
        {
            if (_orderManager.playerCard[i] != _orderManager.currentOrder)
            {
                _orderManager.playerCard[i].score += AddScore[2];
                playerScoreSave.cardSO = _orderManager.playerCard[i];
                playerScoreSave.SaveCardSO();
                playerScoreSave.cardSO = null;
            }
        }
        StartCoroutine(CorAnim());
    }
    public void AnotherScoreDownMethod()
    {

        for (int i = 0; i < _orderManager.playerCard.Length; i++)
        {
            if (_orderManager.playerCard[i] != _orderManager.currentOrder)
            {
                _orderManager.playerCard[i].score -= AddScore[3];
                playerScoreSave.cardSO = _orderManager.playerCard[i];
                playerScoreSave.SaveCardSO();
                playerScoreSave.cardSO = null;
            }
        }
        StartCoroutine(CorAnim());
    }
    public void EveryScoreUpMethod()
    {
        for (int i = 0; i < _orderManager.playerCard.Length; i++)
        {
            _orderManager.playerCard[i].score += AddScore[4];
            playerScoreSave.cardSO = _orderManager.playerCard[i];
            playerScoreSave.SaveCardSO();
            playerScoreSave.cardSO = null;
        }
        StartCoroutine(CorAnim());
    }
    public void EveryScoreDownMethod()
    {
        for (int i = 0; i < _orderManager.playerCard.Length; i++)
        {
            _orderManager.playerCard[i].score -= AddScore[5];
            playerScoreSave.cardSO = _orderManager.playerCard[i];
            playerScoreSave.SaveCardSO();
            playerScoreSave.cardSO = null;
        }
        StartCoroutine(CorAnim());
    }
    public void DoubleScoreMethod()
    {
        ItemManager.Instance.orderPlayer.score *= 2;
        playerScoreSave.cardSO = ItemManager.Instance.orderPlayer;
        playerScoreSave.SaveCardSO();
        playerScoreSave.cardSO = null;
        StartCoroutine(CorAnim());
    }

    private IEnumerator CorAnim()
    {
        yield return new WaitForSeconds(7.5f);
        _itemText.StartCor();
        yield return new WaitForSeconds(2f);
        ItemManager.Instance.orderNum++;
        _orderManager.ItemUsed();
    }
}
