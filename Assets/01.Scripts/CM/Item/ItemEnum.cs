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

    private OrderManager orderManager;
    private ItemFunctions itemFunctions;


    public void OnEnable()
    {
        itemFunctions = GetComponentInParent<ItemFunctions>();
        Debug.Log(itemFunctions);
        orderManager = FindAnyObjectByType<OrderManager>();
        

        type = itemFunctions.GetType();
        type.GetMethod($"{items}Method").Invoke(itemFunctions, null);
        orderManager.ItemUsed();
    }
}