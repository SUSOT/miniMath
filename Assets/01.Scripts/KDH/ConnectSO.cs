using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class ConnectSO : MonoBehaviour
{
    public TMP_InputField InCorrectInputFieldSec;
    public TMP_InputField InCorrectInputFieldFir;
    public TMP_InputField QuestionInputField;
    public TMP_InputField CorrectInputField;
    public TMP_InputField QuestionInput;
    public TMP_InputField CorrectInput;
    public TMP_InputField InCorrectInputFir;
    public TMP_InputField InCorrectInputSec;
    public ProblemSO problem;

    private string GetFilePath()
    {
        return Path.Combine(Application.dataPath, $"{problem.whatIsProblem}_ProblemSO.json");
    }

    public void ApplyValues()
    {
        problem.whatIsProblem = QuestionInput.text;
        problem.CorrectAnswer = CorrectInput.text;
        problem.firstWrongAnswer = InCorrectInputSec.text;
        problem.secondWrongAnswer = InCorrectInputFir.text;
    }

    public void SaveToFile()
    {
        ApplyValues();
        string json = JsonUtility.ToJson(problem);
        File.WriteAllText(GetFilePath(), json);
        Debug.Log($"������ �����: {GetFilePath()}");
    }

    public void LoadFromFile()
    {
        if (File.Exists(GetFilePath()))
        {
            string json = File.ReadAllText(GetFilePath());
            JsonUtility.FromJsonOverwrite(json, problem);
            UpdateInputFields();
            Debug.Log($"������ �ε��: {GetFilePath()}");
        }
        else
        {
            Debug.LogWarning("���̺� ������ ã�� �� ����");
        }
    }

    private void UpdateInputFields()
    {
        QuestionInput.text = problem.whatIsProblem;
        CorrectInput.text = problem.CorrectAnswer;
        InCorrectInputFir.text = problem.firstWrongAnswer;
        InCorrectInputSec.text = problem.secondWrongAnswer;
    }

    void Start()
    {
        QuestionInputField = QuestionInput;
        CorrectInputField = CorrectInput;
        InCorrectInputFieldFir = InCorrectInputFir;
        InCorrectInputFieldSec = InCorrectInputSec;

        TMP_Text placeholderText1 = QuestionInputField.placeholder.GetComponent<TMP_Text>();
        placeholderText1.text = "������ �����ּ��� ...";

        TMP_Text placeholderText2 = CorrectInputField.placeholder.GetComponent<TMP_Text>();
        placeholderText2.text = "������ �����ּ��� ...";

        TMP_Text placeholderText3 = InCorrectInputFieldFir.placeholder.GetComponent<TMP_Text>();
        placeholderText3.text = "������ �����ּ��� ...";

        TMP_Text placeholderText4 = InCorrectInputFieldSec.placeholder.GetComponent<TMP_Text>();
        placeholderText4.text = "������ �����ּ��� ...";
    }

    private void Update()
    {
        ApplyValues();
    }
}
