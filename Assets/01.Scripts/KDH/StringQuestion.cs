using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StringQuestion : MonoBehaviour
{
    public CanvasGroup targetCanvasGroup;
    public RectTransform targetCanvas;

    public Button switchButton;
    public Button returnButton;

    public float animationDuration = .5f;

    void Start()
    {
        targetCanvas.anchoredPosition = new Vector2(0, -Screen.height);
        targetCanvasGroup.alpha = 0;
        targetCanvasGroup.interactable = false;
        targetCanvasGroup.blocksRaycasts = false;

        switchButton.onClick.AddListener(SwitchToTargetCanvas);
        returnButton.onClick.AddListener(ReturnToTargetCanvas);
    }

    void SwitchToTargetCanvas()
    {
        targetCanvasGroup.interactable = true;
        targetCanvasGroup.blocksRaycasts = true;

        targetCanvasGroup.DOFade(1, animationDuration);
        targetCanvas.DOAnchorPosY(0, animationDuration).SetEase(Ease.OutExpo);
    }

    void ReturnToTargetCanvas()
    {
        targetCanvasGroup.interactable = false;
        targetCanvasGroup.blocksRaycasts = false;

        targetCanvasGroup.DOFade(0, 0.5f);
        targetCanvas.DOAnchorPosY(-Screen.height, animationDuration).SetEase(Ease.OutExpo);
    }
}
