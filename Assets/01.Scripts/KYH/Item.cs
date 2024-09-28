using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
public enum DSDHADUKAKUG
{
    MyScoreDown,
    MyScoreUp,
    AnotherScoreDown,
    AnotherScoreUp,
    EveryScoreDown,
    EveryScoreUp,
    DoubleScore
}

public class Item : MonoBehaviour
{
    public DSDHADUKAKUG dasd;

    public void SDDSADAMethod()
    {
        GetType().GetMethod($"{dasd}Method", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Invoke(this, null);
    }

    private void HammerItem(int i)
    {

    }
}
