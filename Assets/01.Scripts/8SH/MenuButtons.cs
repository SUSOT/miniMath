using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour, IPointerClickHandler
{
    private CanvasGroup pause;
    public enum MenuButtonType
    {
        resume,
        BackToMenu,
        Quit,
        Null
    }

    [SerializeField] private MenuButtonType menuBttType = MenuButtonType.Null;

    private void Awake()
    {
        pause = transform.parent.parent.GetComponent<CanvasGroup>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("하 왜 안되...................");
        switch (menuBttType)
        {
            case MenuButtonType.resume:
                Time.timeScale = 1;
                pause.alpha = 0;
                pause.blocksRaycasts = false;
                break;
            case MenuButtonType.BackToMenu:
                SceneManager.LoadScene("TeamSelect");
                break;
            case MenuButtonType.Quit:
                Application.Quit();
                break;
            default: break;
        }
    }
}
