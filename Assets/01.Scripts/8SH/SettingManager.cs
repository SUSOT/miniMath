using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance;

    public float master;
    public float bgm;
    public float sfx;

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

        master = 1;
        bgm = 1;
        sfx = 1;
    }

    public void SetAudioSettings(float slot, float value)
    {
        switch (slot)
        {
            case 0: master = value; break;
            case 1: bgm = value; break;
            case 2: sfx = value; break;
            default: break;
        }
    }
}
