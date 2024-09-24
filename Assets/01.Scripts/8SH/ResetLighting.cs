using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLighting : MonoBehaviour
{
    public enum EnvironmentType
    {
        Soccer,
        Gacha,
        Line,
        Null,
    }

    [SerializeField] private EnvironmentType Type = EnvironmentType.Null;
    [SerializeField] private Material SkyMaterial = null;

    private void Start()
    {
        switch (Type)
        {
            case EnvironmentType.Soccer:
                RenderSettings.skybox = SkyMaterial;
                RenderSettings.ambientLight = Color.cyan;
                RenderSettings.fogColor = Color.white;
                break;
            case EnvironmentType.Gacha:
                RenderSettings.skybox = SkyMaterial;
                RenderSettings.ambientLight = Color.black;
                RenderSettings.fogColor = Color.black;
                break;
            case EnvironmentType.Line:
                RenderSettings.skybox = SkyMaterial;
                RenderSettings.ambientLight = Color.black;
                RenderSettings.fogColor = Color.black;
                break;
            default:break;
        }
    }
}
