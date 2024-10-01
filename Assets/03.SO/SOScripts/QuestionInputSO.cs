using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.IO;
using UnityEngine;

public class QuestionInputSO : MonoBehaviour
{
    public TMP_InputField inputField;
    public ProblemSO problem;

    private string GetFilePath()
    {
        return Path.Combine(Application.dataPath, "WhatIsProblem.json");
    }

    public void SaveToFile()
    {
        problem.whatIsProblem = inputField.text;
        string json = JsonUtility.ToJson(problem);
        File.WriteAllText(GetFilePath(), json);
        Debug.Log("������ �����.");
    }

    public void LoadFromFile()
    {
        if (File.Exists(GetFilePath()))
        {
            string json = File.ReadAllText(GetFilePath());
            JsonUtility.FromJsonOverwrite(json, problem);
            inputField.text = problem.whatIsProblem;
            Debug.Log("������ �ε��.");
        }
        else
        {
            Debug.LogWarning("���̺� ������ ã�� �� ����.");
        }
    }
}
