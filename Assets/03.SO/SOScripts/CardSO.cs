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
        Debug.Log($"데이터가 세이브됨 : {GetFilePath()}");
    }

    public void LoadFromFile()
    {
        if (File.Exists(GetFilePath()))
        {
            string json = File.ReadAllText(GetFilePath());
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log($"데이터가 로드됨 : {GetFilePath()}");
        }
        else
        {
            Debug.LogWarning("세이브 파일을 찾을 수 없음");
        }
    }

    public void ClearSaveFile()
    {
        if (File.Exists(GetFilePath()))
        {
            File.Delete(GetFilePath());
            Debug.Log($"세이브 파일이 삭제됨: {GetFilePath()}");
        }
    }
}
