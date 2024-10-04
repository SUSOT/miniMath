using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonDDOL : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
