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
    public Sprite O;
    public Sprite X;
    public Image[] images;
    public static OX instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Show(OandX ox, int num)
    {
        if (ox == OandX.O)
        {
            images[num].sprite = O;
        }else
        {
            images[num].sprite = X;
        }
        images[num].transform.DOScale(0, 0);
        images[num].transform.DOScale(.5f, 1).SetDelay(0.05f);
        images[num].transform.DOScale(0, 1).SetDelay(2f);
    }
}
