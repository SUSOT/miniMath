using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActive : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    private void Update()
    {
        // Ȱ��ȭ�� ������Ʈ�� ���� ��� CanvasGroup ��Ȱ��ȭ
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
