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
            Debug.LogWarning("QuestionInputSO�� ã�� �� �����ϴ�.");
        }

        if (cis != null)
        {
            cis.LoadFromFile();
        }
        else
        {
            Debug.LogWarning("CorrectInputSO�� ã�� �� �����ϴ�.");
        }

        if (icfs != null)
        {
            icfs.LoadFromFile();
        }
        else
        {
            Debug.LogWarning("InCorrectFirInputSO�� ã�� �� �����ϴ�.");
        }

        if (icss != null)
        {
            icss.LoadFromFile();
        }
        else
        {
            Debug.LogWarning("InCorrectSecInputSO�� ã�� �� �����ϴ�.");
        }
    }
}
