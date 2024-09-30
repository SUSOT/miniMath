using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ItemText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _time = 1f;
    [SerializeField] private List<string> _texts = new List<string>();
    [SerializeField] private MoveItemScene _scene;
    public IEnumerator ItemTextMethod()
    {
        _text.gameObject.SetActive(true);
        _text.text = _texts[_scene.rand];
        yield return new WaitForSeconds(_time);
    }
}
