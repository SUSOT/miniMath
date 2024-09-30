using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class OpenTutorial : MonoBehaviour
{
    public TMP_Text cantStartText;

    public void EnterTeamSelectScene()
    {
        if (ActiveObjManager.Instance.HasActiveObjects())
        {
            SceneManager.LoadScene("TeamSelect");
        }
        else
        {
            ShowCantStartMessage();
        }
    }

    public void EnterAddProblemScene()
    {
        if (ActiveObjManager.Instance.HasActiveObjects())
        {
            SceneManager.LoadScene("AddProblem");
        }
        else
        {
            ShowCantStartMessage();
        }
    }

    private void ShowCantStartMessage()
    {
        cantStartText.alpha = 0;
        cantStartText.DOFade(1, 1)
            .OnComplete(() =>
            {
                cantStartText.DOFade(0, 1);
            });
    }
}
