using DG.Tweening;
using UnityEngine;

public class ChangeTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorial;
    [SerializeField] private int _maxValue;
    [SerializeField] private int _moveValue;
    private int _curValue = 0;

    public void RightMove()
    {
        if (_curValue < _maxValue)
        {
            _tutorial.transform.DOMoveX(_tutorial.transform.position.x -_moveValue, 0.5f);
            _curValue++;
        }
    }
    public void LeftMove()
    {
        if (_maxValue >= _curValue && _curValue > 0)
        {
            _tutorial.transform.DOMoveX(_tutorial.transform.position.x + _moveValue, 0.5f);
            _curValue--;
        }
    }
}
