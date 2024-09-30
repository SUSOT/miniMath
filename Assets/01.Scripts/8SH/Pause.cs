using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool opened = false;
    private CanvasGroup pause;

    private void Awake()
    {
        pause = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (opened)
            {
                opened = false;
                pause.alpha = 0;
                pause.blocksRaycasts = false;
                Time.timeScale = 1;
            }
            else
            {
                opened = true;
                pause.alpha = 1;
                pause.blocksRaycasts = true;
                Time.timeScale = 0;

            }
        }
    }

    public void Open()
    {
        opened = true;
        pause.alpha = 1;
        pause.blocksRaycasts = true;
        Time.timeScale = 0;
    }
}
