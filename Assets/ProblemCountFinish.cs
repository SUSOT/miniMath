using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProblemCountFinish : MonoBehaviour
{
    [SerializeField]
    private Counter counter;

    public void OpenTuTo()
    {
        counter.SettingCount(int.Parse(counter.text.text));
        SceneManager.LoadScene("Tutorial");
    }
}
