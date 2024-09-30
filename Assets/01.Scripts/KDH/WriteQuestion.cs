using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class WriteQuestion : MonoBehaviour
{
    public CanvasGroup currentCanvasGroup;
    public RectTransform currentCanvasTransform;
    public Button switchButton;
    public CanvasGroup targetCanvasGroup;
    public RectTransform targetCanvasTransform;
    private bool isAnimating = false;

    void Start()
    {
        targetCanvasTransform.anchoredPosition = new Vector2(0, -Screen.height);
        targetCanvasGroup.interactable = false;
        targetCanvasGroup.blocksRaycasts = false;

        switchButton.onClick.AddListener(() => StartCoroutine(SwitchCanvasEffect()));
    }

    private IEnumerator SwitchCanvasEffect()
    {
        if (isAnimating) yield break;
        isAnimating = true;

        Vector3 originalScale = switchButton.transform.localScale;
        switchButton.transform.DOScale(originalScale * 0.9f, 0.1f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.1f);
        switchButton.transform.DOScale(originalScale, 0.1f).SetEase(Ease.OutBack);

        currentCanvasGroup.interactable = false;
        currentCanvasGroup.blocksRaycasts = false;
        currentCanvasTransform.DOAnchorPosY(-Screen.height, 1f).SetEase(Ease.OutBounce);

        yield return new WaitForSeconds(1f);

        targetCanvasGroup.interactable = true;
        targetCanvasGroup.blocksRaycasts = true;
        targetCanvasTransform.DOAnchorPosY(0, 1f).SetEase(Ease.OutBounce);

        yield return new WaitForSeconds(1f);

        isAnimating = false;
    }
}
