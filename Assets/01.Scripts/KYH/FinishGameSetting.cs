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
            print("����ġ ����");
            teamCount++;
            if (teamSignature.cardSO.teamName.Length < 1)
            {
                textWarning.WarningText("�� �̸��� �����ּ���");
                return;
            }    
        }
        if(teamCount > 1)
        {
            GameManager.Instance.TeamIconSet();
            SceneManager.LoadScene("MiniGame");
        }
        else
            textWarning.WarningText("ȥ�ڼ��� ������ ������ �� �����ϴ�.");
    }
}
