using System.IO;
using TMPro;
using UnityEngine;

public class InCorrectSecInputSO : MonoBehaviour
{
    public TMP_InputField inputField;
    public ProblemSO problem;

    private string GetFilePath()
    {
        return Path.Combine(Application.dataPath, "SecondWrongAnswer.json");
    }

    public void SaveToFile()
    {
        problem.secondWrongAnswer = inputField.text;
        string json = JsonUtility.ToJson(problem);
        File.WriteAllText(GetFilePath(), json);
        Debug.Log("���� 2�� �����.");
    }

    public void LoadFromFile()
    {
        if (File.Exists(GetFilePath()))
        {
            string json = File.ReadAllText(GetFilePath());
            JsonUtility.FromJsonOverwrite(json, problem);
            inputField.text = problem.secondWrongAnswer;
            Debug.Log("���� 2�� �ε��.");
        }
        else
        {
            Debug.LogWarning("���̺� ������ ã�� �� ����.");
        }
    }
}
