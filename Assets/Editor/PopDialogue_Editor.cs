using UnityEngine;
using System.Collections;
using UnityEditor;
using DialogueHelpers;

[CustomEditor(typeof(PopDialogue))]
public class PopDialogue_Editor : Editor
{

    protected SerializedObject GetTarget;
    protected SerializedProperty DisplayTimeTarget;
    protected SerializedProperty AutoStartTarget;
    protected SerializedProperty InteractTarget;
    protected SerializedProperty LinkTarget;
    protected SerializedProperty TextTarget;
    protected SerializedProperty DialogueIDTarget;

    protected bool showDisplayTimer;

    void OnEnable()
    {
        InitSerialized(); 
    }

    protected virtual void SetMyTarget()
    {
        GetTarget = new SerializedObject((PopDialogue)target);
    }

    protected virtual void InitSerialized()
    {
        showDisplayTimer = true;
        SetMyTarget();
        DisplayTimeTarget = GetTarget.FindProperty("displayTime");
        AutoStartTarget = GetTarget.FindProperty("autoStart");
        InteractTarget = GetTarget.FindProperty("interactData");
        TextTarget = GetTarget.FindProperty("bodyText");
        DialogueIDTarget = GetTarget.FindProperty("dialogueID");
        LinkTarget = GetTarget.FindProperty("linkNarrative");
    }

    public override void OnInspectorGUI()
    {
        if(showDisplayTimer)
            EditorGUILayout.PropertyField(DisplayTimeTarget);

        EditorGUILayout.PropertyField(AutoStartTarget);

        if (!((PopDialogue)target).autoStart && InteractTarget != null)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(InteractTarget);
            EditorGUI.indentLevel--;
        }

        ShowExitCondition();

        EditorGUILayout.PropertyField(LinkTarget);
        if (((PopDialogue)target).linkNarrative)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(DialogueIDTarget);
            EditorGUI.indentLevel--;
        }

        if(TextTarget != null)
            EditorGUILayout.PropertyField(TextTarget, true);

        if (GUILayout.Button("Populate Narrative"))
        {
            OnPopulateNarrative();
        }
        
        GetTarget.ApplyModifiedProperties();
    }

    protected virtual void ShowExitCondition()
    {
        //not used for pop dialogue, but is used in ChoiceDialogue
    }

    protected virtual void OnPopulateNarrative()
    {
        GameObject narrativeObject = GameObject.FindGameObjectWithTag("Narrative");
        NarrativeStorage sceneStorage = narrativeObject.GetComponent<NarrativeStorage>();
        sceneStorage.Initialize();
        ((PopDialogue)target).PullNarrativePages(sceneStorage);
        ((PopDialogue)target).SyncByInspector();
        EditorUtility.SetDirty(target);
    }

    
}