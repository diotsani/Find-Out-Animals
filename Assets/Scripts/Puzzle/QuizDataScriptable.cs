using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Questiondata", menuName = "QuestionData", order = 1)]
public class QuizDataScriptable : ScriptableObject
{
    public List<QuestionData> questions;
}
