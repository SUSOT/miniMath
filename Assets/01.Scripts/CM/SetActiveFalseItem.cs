using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SetActiveFalseItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private PlayableAsset timeLine;
    public void ActiveFalseItemMethod()
    {
        ItemManager.instance.ItemList[ItemManager.instance.randItem].SetActive(false);
        _text.text = "";
    }
}
