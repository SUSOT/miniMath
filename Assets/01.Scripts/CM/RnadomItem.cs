using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RnadomItem : MonoBehaviour
{
    public void CreateRandomItem(){
        int rand = UnityEngine.Random.Range(0, ItemManager.instance.ItemList.Count);
    }
}
