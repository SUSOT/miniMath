using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Menu : MonoBehaviour, IPointerClickHandler
{
    public enum MenuType
    {
        Menu,
        Setting,
        Credit,
        Null
    }

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject credit;

    [SerializeField] private MenuType menuType = MenuType.Null;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (menuType)
        {
            case MenuType.Menu:
                menu.SetActive(true);
                setting.SetActive(false);
                credit.SetActive(false);
                break;
            case MenuType.Setting:
                menu.SetActive(false);
                setting.SetActive(true);
                credit.SetActive(false);
                break;
            case MenuType.Credit:
                menu.SetActive(false);
                setting.SetActive(false);
                credit.SetActive(true);
                break;
            default: break;
        }
    }
}
