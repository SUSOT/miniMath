using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/ProblemList")]
public class ProblemList : ScriptableObject
{
    public List<ProblemSO> problemSO = new List<ProblemSO>();
}
