using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private Slider _timerSlider;
    [SerializeField] private float _coolDownTime = 120;
    private float _currentTime;
    private bool isInvoke = false;
    public UnityEvent TimeOver;


    private void Start()
    {
        _timerSlider.maxValue = _coolDownTime;
        _currentTime = _coolDownTime;
    }

    private void FixedUpdate()
    {
        if (_timerSlider.value <= 0 && isInvoke == false)
        {
            TimeOver?.Invoke();
            Debug.Log("TimeOVer");
            isInvoke = true;
        }
        else if(_timerSlider.gameObject.activeSelf)
        {
            _currentTime -= Time.fixedDeltaTime;
        }
        _timerSlider.value = _currentTime;

    }
}