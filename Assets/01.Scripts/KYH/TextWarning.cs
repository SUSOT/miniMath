using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextWarning : MonoBehaviour
{
    public TextMeshProUGUI warningText;
    public void WarningText(string text)
    {
        warningText.text = text;
        StartCoroutine(TextFadeRoutine());
    }

    private IEnumerator TextFadeRoutine()
    {
        warningText.DOFade(1,1);
        yield return new WaitForSeconds(2f);
        warningText.DOFade(0, 1);
    }
}
