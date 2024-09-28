using System.Collections.Generic;
using UnityEngine;

public class ActiveObjManager : MonoBehaviour
{
    public static ActiveObjManager Instance;

    private List<GameObject> activeList = new List<GameObject>();

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

    public void AddObject(GameObject obj)
    {
        if (!activeList.Contains(obj))
        {
            activeList.Add(obj);
        }
    }

    public GameObject GetLastObject()
    {
        if (activeList.Count > 0)
        {
            return activeList[activeList.Count - 1];
        }
        return null;
    }

    public void RemoveObject()
    {
        if (activeList.Count > 0)
        {
            activeList.RemoveAt(activeList.Count - 1);
        }
    }

    public bool HasActiveObjects()
    {
        return activeList.Count > 0;
    }
}
