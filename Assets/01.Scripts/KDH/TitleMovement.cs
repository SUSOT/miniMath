using UnityEngine;
using TMPro;
using DG.Tweening;

public class TitleMovement : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public float moveAmount = 5f;
    public float scaleAmount = 0.1f;
    public float rotationAmount = 2f;
    public float duration = 1f;

    void Start()
    {
        AnimateTitle();
    }

    void AnimateTitle()
    {
        Vector3 originalScale = titleText.rectTransform.localScale;

        Sequence sequence = DOTween.Sequence();

        Tween scaleUp = titleText.rectTransform
            .DOScale(originalScale + new Vector3(scaleAmount, scaleAmount, 0), duration)
            .SetEase(Ease.OutBack);
        Tween rotateRight = titleText.rectTransform
            .DORotate(new Vector3(0, 0, rotationAmount), duration)
            .SetEase(Ease.OutBack);

        sequence.Append(scaleUp).Join(rotateRight);

        Tween scaleDown = titleText.rectTransform
            .DOScale(originalScale, duration)
            .SetEase(Ease.OutBack);
        Tween rotateBack = titleText.rectTransform
            .DORotate(new Vector3(0, 0, 0), duration)
            .SetEase(Ease.OutBack);

        sequence.Append(scaleDown).Join(rotateBack);

        Tween scaleUpAgain = titleText.rectTransform
            .DOScale(originalScale + new Vector3(scaleAmount, scaleAmount, 0), duration)
            .SetEase(Ease.OutBack);
        Tween rotateLeft = titleText.rectTransform
            .DORotate(new Vector3(0, 0, -rotationAmount), duration)
            .SetEase(Ease.OutBack);

        sequence.Append(scaleUpAgain).Join(rotateLeft);

        Tween scaleDownAgain = titleText.rectTransform
            .DOScale(originalScale, duration)
            .SetEase(Ease.OutBack);
        Tween rotateBackAgain = titleText.rectTransform
            .DORotate(new Vector3(0, 0, 0), duration)
            .SetEase(Ease.OutBack);

        sequence.Append(scaleDownAgain).Join(rotateBackAgain);

        sequence.SetLoops(-1);
    }
}
