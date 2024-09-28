using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public enum Items
{
    MyScoreUp,
    MyScoreDown,
    AnotherScoreUp,
    AnotherScoreDown,
    EveryScoreUp,
    EveryScoreDown,
    DoubleScore
}
public class ItemEnum : MonoBehaviour
{
    public Items items;
    Type type;

    public void OnEnable()
    {
        ItemFunctions itemFunction = new ItemFunctions();

        type = itemFunction.GetType();
        type.GetMethod($"{items}Method").Invoke(itemFunction, null);
    }
}