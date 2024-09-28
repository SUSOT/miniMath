using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AddProblem")]
public class ProblemSO : ScriptableObject
{
    [Header("������ ���� ���� ��")]
    public string whatIsProblem;

    [Header("����")]
    public string CorrectAnswer;

    [Header("����1")]
    public string secondWrongAnswer;

    [Header("����2")]
    public string firstWrongAnswer;
}
