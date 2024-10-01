using System.IO;
using TMPro;
using UnityEngine;

public class InCorrectFirInputSO : MonoBehaviour
{
    public TMP_InputField inputField;
    public ProblemSO problem;

    private string GetFilePath()
    {
        return Path.Combine(Application.dataPath, "FirstWrongAnswer.json");
    }

    public void SaveToFile()
    {
        problem.firstWrongAnswer = inputField.text;
        string json = JsonUtility.ToJson(problem);
        File.WriteAllText(GetFilePath(), json);
        Debug.Log("���� 1�� �����.");
    }

    public void LoadFromFile()
    {
        if (File.Exists(GetFilePath()))
        {
            string json = File.ReadAllText(GetFilePath());
            JsonUtility.FromJsonOverwrite(json, problem);
            inputField.text = problem.firstWrongAnswer;
            Debug.Log("���� 1�� �ε��.");
        }
        else
        {
            Debug.LogWarning("���̺� ������ ã�� �� ����.");
        }
    }
}
