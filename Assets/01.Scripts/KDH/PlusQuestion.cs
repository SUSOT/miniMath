using UnityEngine;
using UnityEngine.UI;

public class PlusQuestion : MonoBehaviour
{
    public static PlusQuestion Instance;
    public Button plusButton;
    public GameObject[] targets;

    private int currentIndex = 0;

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
        plusButton.onClick.AddListener(OnPlusButtonClick);
        UpdatePlusButtonState();
    }

    public void UpdatePlusButtonState()
    {
        plusButton.interactable = currentIndex < targets.Length;
        MinusQuestion.Instance.UpdateMinusButtonState();
    }

    private void OnPlusButtonClick()
    {
        if (currentIndex < targets.Length)
        {
            GameObject currentTarget = targets[currentIndex];
            currentTarget.SetActive(true);
            ActiveObjManager.Instance.AddObject(currentTarget);
            currentIndex++;
        }

        UpdatePlusButtonState();
    }

    public void ResetCurrentIndex()
    {
        currentIndex = 0;
        UpdatePlusButtonState();
    }
}
