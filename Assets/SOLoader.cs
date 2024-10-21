using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOLoader : MonoBehaviour
{
    private QuestionInputSO qis;
    private CorrectInputSO cis;
    private InCorrectFirInputSO icfs;
    private InCorrectSecInputSO icss;

    private void Awake()
    {
        qis = FindObjectOfType<QuestionInputSO>();
        cis = FindObjectOfType<CorrectInputSO>();
        icfs = FindObjectOfType<InCorrectFirInputSO>();
        icss = FindObjectOfType<InCorrectSecInputSO>();

        if (qis != null)
        {
            qis.LoadFromFile();
        }
        else
        {
            Debug.LogWarning("QuestionInputSO를 찾을 수 없습니다.");
        }

        if (cis != null)
        {
            cis.LoadFromFile();
        }
        else
        {
            Debug.LogWarning("CorrectInputSO를 찾을 수 없습니다.");
        }

        if (icfs != null)
        {
            icfs.LoadFromFile();
        }
        else
        {
            Debug.LogWarning("InCorrectFirInputSO를 찾을 수 없습니다.");
        }

        if (icss != null)
        {
            icss.LoadFromFile();
        }
        else
        {
            Debug.LogWarning("InCorrectSecInputSO를 찾을 수 없습니다.");
        }
    }
}
