using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Timeline;

public enum OandX
{
    O,
    X
}

public class OX : MonoBehaviour
{
    public static Sprite O;
    public static Sprite X;
    public static Image image;
    public static SettingManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Show(OandX ox)
    {
        if (ox == OandX.O)
        {
            image.sprite = O;
        }else
        {
            image.sprite = X;
        }
        image.transform.DOScale(0, 0);
        image.transform.DOScale(3, 1).SetDelay(0.05f);
        image.transform.DOScale(0, 1).SetDelay(2f);
    }
}
