using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLighting : MonoBehaviour
{
    public enum EnvironmentType
    {
        Soccer,
        Gacha,
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
                RenderSettings.ambientLight = new Color(195f / 255f, 1,1);
                RenderSettings.fogColor = Color.white;
                RenderSettings.fogDensity = 0f;
                break;
            case EnvironmentType.Gacha:
                RenderSettings.skybox = SkyMaterial;
                RenderSettings.ambientLight = Color.black;
                RenderSettings.fogColor = Color.black;
                RenderSettings.fogDensity = 0f;
                break;
            default:break;
        }
    }
}
