using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/MiniGameSOList")]
public class MiniGameSoList : ScriptableObject
{
    public List<MiniGameSO> randomMiniGameList = new();
}
