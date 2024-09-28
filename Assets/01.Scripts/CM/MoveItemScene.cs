using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItemScene : MonoBehaviour{
    private int rand;
    [SerializeField] private GameObject panel;

    public void MoveItemCutScene(){
        rand = Random.Range(0, ItemManager.instance.ItemList.Count);
        ItemManager.instance.ItemList[rand].SetActive(true);
        panel.SetActive(false);
    }
}
