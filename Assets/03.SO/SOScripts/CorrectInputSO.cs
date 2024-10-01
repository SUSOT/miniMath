using System.IO;
using TMPro;
using UnityEngine;

public class CorrectInputSO : MonoBehaviour
{
    public TMP_InputField inputField;
    public ProblemSO problem;

    private string GetFilePath()
    {
        return Path.Combine(Application.dataPath, "CorrectAnswer.json");
    }

    public void SaveToFile()
    {
        problem.CorrectAnswer = inputField.text;
        string json = JsonUtility.ToJson(problem);
        File.WriteAllText(GetFilePath(), json);
        Debug.Log("정답이 저장됨.");
    }

    public void LoadFromFile()
    {
        if (File.Exists(GetFilePath()))
        {
            string json = File.ReadAllText(GetFilePath());
            JsonUtility.FromJsonOverwrite(json, problem);
            inputField.text = problem.CorrectAnswer;
            Debug.Log("정답이 로드됨.");
        }
        else
        {
            Debug.LogWarning("세이브 파일을 찾을 수 없음.");
        }
    }
}
