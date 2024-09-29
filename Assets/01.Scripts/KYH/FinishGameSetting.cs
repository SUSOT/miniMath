using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameSetting : MonoBehaviour
{
    [SerializeField]
    private GameObject teamIcon;

    private TeamSignatureNumber[] teamSignatureNumbers;
    private int teamCount;

    [SerializeField]
    private TextWarning textWarning;

    public void StartGame()
    {
        teamCount = 0;
        teamSignatureNumbers = teamIcon.GetComponentsInChildren<TeamSignatureNumber>();

        foreach(TeamSignatureNumber teamSignature in teamSignatureNumbers)
        {
            print("포이치 들어옴");
            teamCount++;
            if (teamSignature.cardSO.teamName.Length < 1)
            {
                textWarning.WarningText("팀 이름을 정해주세요");
                return;
            }    
        }
        if(teamCount > 1)
        {
            GameManager.Instance.TeamIconSet();
            SceneManager.LoadScene("MiniGame");
        }
        else
            textWarning.WarningText("혼자서는 게임을 시작할 수 없습니다.");
    }
}
