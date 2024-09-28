using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public ScrollRect scrollRect;

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            scrollRect.verticalNormalizedPosition += 0.1f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            scrollRect.verticalNormalizedPosition -= 0.1f;
        }
    }
}
