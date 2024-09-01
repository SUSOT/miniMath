using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private Slider _timerSlider;
    [SerializeField] private int _coolDownTime = 120;
    [SerializeField] private float _currentTime;
    public UnityEvent TimeOver;


    private void Start()
    {
        _timerSlider.maxValue = _coolDownTime;
        _currentTime = _coolDownTime;
    }

    private void FixedUpdate()
    {
        if (_timerSlider.value < 0)
        {
            TimeOver?.Invoke();
        }
        else
        {
            _currentTime -= Time.fixedDeltaTime;
        }
        _timerSlider.value = _currentTime;

    }
}