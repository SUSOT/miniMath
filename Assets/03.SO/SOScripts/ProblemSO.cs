using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AddProblem")]
public class ProblemSO : ScriptableObject
{
    [Header("문제가 뭔지 넣을 값")]
    public string whatIsProblem;

    [Header("정답")]
    public string CorrectAnswer;

    [Header("오답1")]
    public string secondWrongAnswer;

    [Header("오답2")]
    public string firstWrongAnswer;
}
