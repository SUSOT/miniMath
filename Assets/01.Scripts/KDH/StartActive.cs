using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActive : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    private void Update()
    {
        // 활성화된 오브젝트가 없을 경우 CanvasGroup 비활성화
        if (!ActiveObjManager.Instance.HasActiveObjects())
        {
            SetCanvasGroupState(false);
        }
        else
        {
            SetCanvasGroupState(true);
        }
    }

    private void SetCanvasGroupState(bool state)
    {
        canvasGroup.interactable = state;
        canvasGroup.blocksRaycasts = state;
    }
}
