using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private GameObject _door1;
    [SerializeField] private GameObject _door2;
    [SerializeField] private GameObject _door3;
    [SerializeField] private float _openTime = 3f;
    public void OpenDoor()
    {
        _door1.transform.DORotate(new Vector3(0, 90, 0), _openTime).SetEase(Ease.Linear);
        _door2.transform.DORotate(new Vector3(0, 90, 0), _openTime).SetEase(Ease.Linear);
        _door3.transform.DORotate(new Vector3(0, 90, 0), _openTime).SetEase(Ease.Linear);
    }
}
