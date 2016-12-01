using UnityEngine;
using System.Collections;
using UnityEditor;
using DialogueHelpers;

[CustomEditor(typeof(ChoiceDialogue))]
public class ChoiceDialogue_Editor : PopDialogue_Editor
{

    protected SerializedProperty ExitConditionTarget;
    protected SerializedProperty ExitButtonTarget;

    void OnEnable()
    {
        InitSerialized();
    }

    protected override void SetMyTarget()
    {
        GetTarget = new SerializedObject((ChoiceDialogue)target);
    }

    protected override void InitSerialized()
    {
        base.InitSerialized();
        showDisplayTimer = false;
        TextTarget = GetTarget.FindProperty("clickablePages");
        ExitConditionTarget = GetTarget.FindProperty("exitCondition");
        ExitButtonTarget = GetTarget.FindProperty("exitObject");
    }

    protected override void ShowExitCondition()
    {
        //EditorGUILayout.PropertyField(ExitConditionTarget);

        //if(((ChoiceDialogue)target).exitCondition == ChoiceDialogue.ExitConditions.EXIT_BUTTON)
        //{
        //    EditorGUILayout.PropertyField(ExitButtonTarget);
        //}
    }

}
