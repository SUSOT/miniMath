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
        Debug.Log($"문제가 저장됨: {GetFilePath()}");
    }

    public void LoadFromFile()
    {
        if (File.Exists(GetFilePath()))
        {
            string json = File.ReadAllText(GetFilePath());
            JsonUtility.FromJsonOverwrite(json, problem);
            UpdateInputFields();
            Debug.Log($"문제가 로드됨: {GetFilePath()}");
        }
        else
        {
            Debug.LogWarning("세이브 파일을 찾을 수 없음");
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
        placeholderText1.text = "문제를 적어주세요 ...";

        TMP_Text placeholderText2 = CorrectInputField.placeholder.GetComponent<TMP_Text>();
        placeholderText2.text = "정답을 적어주세요 ...";

        TMP_Text placeholderText3 = InCorrectInputFieldFir.placeholder.GetComponent<TMP_Text>();
        placeholderText3.text = "오답을 적어주세요 ...";

        TMP_Text placeholderText4 = InCorrectInputFieldSec.placeholder.GetComponent<TMP_Text>();
        placeholderText4.text = "오답을 적어주세요 ...";
    }

    private void Update()
    {
        ApplyValues();
    }
}
