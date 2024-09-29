using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTutorial : MonoBehaviour
{
    public void ExitScene()
    {
        SceneManager.LoadScene("MiniGame");
    }
}
