using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTutorial : MonoBehaviour
{
    public void EnterTeamSelectScene()
    {
        SceneManager.LoadScene("TeamSelect");
    }

    public void EnterAddProblemScene()
    {
        SceneManager.LoadScene("AddProblem");
    }
}
