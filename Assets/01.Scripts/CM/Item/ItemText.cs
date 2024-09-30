using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ItemText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _time = 1f;
    [SerializeField] private float _waitTime = 7f;
    [SerializeField] private List<string> _texts = new List<string>();
    public IEnumerator ItemTextMethod()
    {
        yield return new WaitForSeconds(_waitTime);
        _text.gameObject.SetActive(true);
        _text.text = _texts[0];
        yield return new WaitForSeconds(_time);
    }
}
