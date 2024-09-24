using UnityEngine;
using DG.Tweening;
using System.Collections;

public class QuestionUI : MonoBehaviour
{
    public CanvasGroup uiCanvasGroup;
    public RectTransform uiCanvasTransform;
    private bool isVisible = false;

    void Start()
    {
        uiCanvasTransform.anchoredPosition = new Vector2(Screen.width, 0);
        uiCanvasGroup.interactable = false;
        uiCanvasGroup.blocksRaycasts = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isVisible)
            {
                StartCoroutine(HandleInput());
                uiCanvasTransform.DOAnchorPosX(Screen.width, 1f).SetEase(Ease.OutSine);
                uiCanvasGroup.interactable = false;
                uiCanvasGroup.blocksRaycasts = false;
                isVisible = false;
            }
            else
            {
                StartCoroutine(HandleInput());
                uiCanvasTransform.DOAnchorPosX(0, 1f).SetEase(Ease.OutSine);
                uiCanvasGroup.interactable = true;
                uiCanvasGroup.blocksRaycasts = true;
                isVisible = true;
            }
        }
    }

    private IEnumerator HandleInput()
    {
        yield return new WaitForSeconds(1f);
    }
}
