using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameSetting : MonoBehaviour
{
    [SerializeField]
    private SettingTeam settingTeam;
    public CharacterImageChange[] characterImageChanges;


    public void StartGame()
    {
        GameManager.Instance.teamCount = settingTeam.currentNum;

        foreach(CharacterImageChange imageChange in characterImageChanges)
        {
            GameManager.Instance.teamsIcon.Add(imageChange.currentCardNum + 1, imageChange.characterImage.sprite);
        }
        SceneManager.LoadScene("MiniGame");
    }
}
