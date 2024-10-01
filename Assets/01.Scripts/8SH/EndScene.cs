using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndScene : MonoBehaviour
{
    private Image fade;
    private TextMeshProUGUI text;
    [SerializeField] private GameObject cam;
    [SerializeField] private RectTransform ui;


    private void Start()
    {
        fade = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(Cutscene());
    }

    private IEnumerator Cutscene()
    {
        yield return new WaitForSecondsRealtime(1);
        text.DOFade(1, 2);
        yield return new WaitForSecondsRealtime(4);
        fade.DOFade(0, 1);
        text.DOFade(0, 1);
        cam.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        ui.DOAnchorPosX(100, 2);
    }
}
