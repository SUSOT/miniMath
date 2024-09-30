using UnityEngine;
using DG.Tweening;
using System.Collections;

public class QuestionUI : MonoBehaviour
{
    public CanvasGroup uiCanvasGroup;
    public RectTransform uiCanvasTransform;
    private bool isVisible = false;
    private bool isAnimatingUI = false;
    void Start()
    {
        uiCanvasTransform.anchoredPosition = new Vector2(0, -Screen.height);
        uiCanvasGroup.interactable = false;
        uiCanvasGroup.blocksRaycasts = false;
    }

    public void StartUI()
    {
        if (isVisible)
        {
            StartCoroutine(HandleBounceEffect(-Screen.height));
            isVisible = false;
        }
        else
        {
            StartCoroutine(HandleBounceEffect(0));
            isVisible = true;
        }
    }

    private IEnumerator HandleBounceEffect(float targetPosY)
    {
        isAnimatingUI = true;
        uiCanvasGroup.interactable = false;
        uiCanvasGroup.blocksRaycasts = false;

        uiCanvasTransform.DOAnchorPosY(targetPosY, 1f).SetEase(Ease.OutBounce);

        yield return new WaitForSeconds(1f);

        if (targetPosY == 0)
        {
            uiCanvasGroup.interactable = true;
            uiCanvasGroup.blocksRaycasts = true;
        }

        isAnimatingUI = false;
    }
}
