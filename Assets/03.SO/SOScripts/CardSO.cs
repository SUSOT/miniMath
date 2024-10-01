using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(menuName = "SO/PlayerInfo")]
public class CardSO : ScriptableObject
{
    public Sprite cardImage;
    public string teamName;
    public int score;
    public bool isCorrectAnswer;

    private string GetFilePath()
    {
        return Path.Combine(Application.dataPath, $"{teamName}_CardSO.json");
    }

    private void Awake()
    {
        ClearSaveFile();
    }

    public void SaveToFile()
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(GetFilePath(), json);
        Debug.Log($"�����Ͱ� ���̺�� : {GetFilePath()}");
    }

    public void LoadFromFile()
    {
        if (File.Exists(GetFilePath()))
        {
            string json = File.ReadAllText(GetFilePath());
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log($"�����Ͱ� �ε�� : {GetFilePath()}");
        }
        else
        {
            Debug.LogWarning("���̺� ������ ã�� �� ����");
        }
    }

    public void ClearSaveFile()
    {
        if (File.Exists(GetFilePath()))
        {
            File.Delete(GetFilePath());
            Debug.Log($"���̺� ������ ������: {GetFilePath()}");
        }
    }
}
