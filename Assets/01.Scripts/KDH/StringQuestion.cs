using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class StringQuestion : MonoBehaviour
{
    public CanvasGroup currentCanvasGroup;
    public RectTransform currentCanvasTransform;
    public Button switchButton;
    public Button backButton;
    public CanvasGroup targetCanvasGroup;
    public RectTransform targetCanvasTransform;
    private bool isAnimating = false;

    void Start()
    {
        targetCanvasTransform.anchoredPosition = new Vector2(0, Screen.height);
        targetCanvasGroup.interactable = false;
        targetCanvasGroup.blocksRaycasts = false;

        switchButton.onClick.AddListener(() => StartCoroutine(SwitchCanvasEffect()));
        backButton.onClick.AddListener(() => StartCoroutine(BackToCurrentCanvasEffect()));
    }

    private IEnumerator SwitchCanvasEffect()
    {
        if (isAnimating) yield break;
        isAnimating = true;

        currentCanvasGroup.interactable = false;
        currentCanvasGroup.blocksRaycasts = false;
        currentCanvasTransform.DOAnchorPosY(-Screen.height, 0.5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(0.5f);

        targetCanvasGroup.interactable = false;
        targetCanvasGroup.blocksRaycasts = false;
        targetCanvasTransform.anchoredPosition = new Vector2(0, Screen.height);
        targetCanvasGroup.alpha = 1;
        targetCanvasTransform.DOAnchorPosY(0, 0.5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(0.5f);

        targetCanvasGroup.interactable = true;
        targetCanvasGroup.blocksRaycasts = true;
        isAnimating = false;
    }

    private IEnumerator BackToCurrentCanvasEffect()
    {
        if (isAnimating) yield break;
        isAnimating = true;

        targetCanvasGroup.interactable = false;
        targetCanvasGroup.blocksRaycasts = false;
        targetCanvasTransform.DOAnchorPosY(Screen.height, 0.5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(0.5f);

        currentCanvasGroup.interactable = false;
        currentCanvasGroup.blocksRaycasts = false;
        currentCanvasTransform.DOAnchorPosY(0, 0.5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(0.5f);

        currentCanvasGroup.interactable = true;
        currentCanvasGroup.blocksRaycasts = true;
        isAnimating = false;
    }
}
