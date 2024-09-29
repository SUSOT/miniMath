using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextWarning : MonoBehaviour
{
    public TextMeshProUGUI warningText;
    Sequence _seq;

    public void WarningText(string text)
    {
        warningText.gameObject.SetActive(true);
        warningText.text = text;
        SafeKill(_seq);

        _seq = DOTween.Sequence()
            .Append(warningText.DOFade(duration: 1f, endValue: 1))
            .Append(warningText.DOFade(duration: 1, endValue: 0))
            .AppendCallback(() => warningText.gameObject.SetActive(false));
    }


    public void SafeKill(Tween tween)
    {
        if (tween is not null && tween.IsActive())
            tween.Complete();
    }
}
