using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MiniGameSetting
{
    public Material changeMaterial;

    public override void Enter()
    {
        base.Enter();
        gameObject.GetComponent<MeshRenderer>().material = changeMaterial;
    }
}
