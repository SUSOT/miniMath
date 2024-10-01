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
        Debug.Log("������ �����.");
    }

    public void LoadFromFile()
    {
        if (File.Exists(GetFilePath()))
        {
            string json = File.ReadAllText(GetFilePath());
            JsonUtility.FromJsonOverwrite(json, problem);
            inputField.text = problem.CorrectAnswer;
            Debug.Log("������ �ε��.");
        }
        else
        {
            Debug.LogWarning("���̺� ������ ã�� �� ����.");
        }
    }
}
