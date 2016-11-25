using UnityEngine;
using System.Collections;
using UnityEditor;
using DialogueHelpers;

[CustomEditor(typeof(PopDialogue))]
public class PopDialogue_Editor : Editor
{
    PopDialogue myTarget;
    SerializedObject GetTarget;
    SerializedProperty DisplayTimeTarget;
    SerializedProperty AutoStartTarget;
    SerializedProperty InteractTarget;
    SerializedProperty LinkTarget;
    SerializedProperty TextTarget;
    SerializedProperty DialogueIDTarget;

    void OnEnable()
    {
        myTarget = (PopDialogue)target;
        GetTarget = new SerializedObject(myTarget);
        DisplayTimeTarget = GetTarget.FindProperty("displayTime");
        AutoStartTarget = GetTarget.FindProperty("autoStart");
        InteractTarget = GetTarget.FindProperty("interactData");
        TextTarget = GetTarget.FindProperty("bodyText");
        DialogueIDTarget = GetTarget.FindProperty("dialogueID");
        LinkTarget = GetTarget.FindProperty("linkNarrative");
    }

    public override void OnInspectorGUI()
    {

        EditorGUILayout.PropertyField(DisplayTimeTarget);

        EditorGUILayout.PropertyField(AutoStartTarget);

        if (!myTarget.autoStart && InteractTarget != null)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(InteractTarget);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.PropertyField(LinkTarget);
        if (myTarget.linkNarrative)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(DialogueIDTarget);
            EditorGUI.indentLevel--;
        }

        if(TextTarget != null)
            EditorGUILayout.PropertyField(TextTarget);

        if (GUILayout.Button("Populate Narrative"))
        {
            GameObject narrativeObject = GameObject.FindGameObjectWithTag("Narrative");
            NarrativeStorage sceneStorage = narrativeObject.GetComponent<NarrativeStorage>();
            sceneStorage.Initialize();
            myTarget.PullNarrativePages(sceneStorage);
            myTarget.SyncByInspector();
            EditorUtility.SetDirty(target);
        }
        
        GetTarget.ApplyModifiedProperties();
    }

    
}