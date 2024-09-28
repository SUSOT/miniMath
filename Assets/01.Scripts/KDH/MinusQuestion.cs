using UnityEngine;
using UnityEngine.UI;

public class MinusQuestion : MonoBehaviour
{
    public static MinusQuestion Instance;
    public Button minusButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        minusButton.onClick.AddListener(OnMinusButtonClick);
        UpdateMinusButtonState();
    }

    public void UpdateMinusButtonState()
    {
        minusButton.interactable = ActiveObjManager.Instance.HasActiveObjects();
    }

    private void OnMinusButtonClick()
    {
        GameObject lastTarget = ActiveObjManager.Instance.GetLastObject();

        if (lastTarget != null)
        {
            lastTarget.SetActive(false);
            ActiveObjManager.Instance.RemoveObject();

            PlusQuestion.Instance.ResetCurrentIndex();
        }

        UpdateMinusButtonState();
        PlusQuestion.Instance.UpdatePlusButtonState();
    }
}
