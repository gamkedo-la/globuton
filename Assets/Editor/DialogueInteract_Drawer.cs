using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomPropertyDrawer(typeof(DialogueHelpers.DialogueInteract))]
class DialogueInteract_Drawer : PropertyDrawer
{
    bool foldInteract = false;

    //override propertyHeight, too much space before the property
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) { return 0f; }

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        foldInteract = EditorGUILayout.Foldout(foldInteract, label); 
        if (foldInteract)
        {
            EditorGUI.indentLevel++;
            SerializedProperty watchDialogue = property.FindPropertyRelative("watchDialogue");
            SerializedProperty watchInteract = property.FindPropertyRelative("watchInteract");
            SerializedProperty delayedInteract = property.FindPropertyRelative("delayedInteract");
            EditorGUILayout.PropertyField(watchDialogue);
            EditorGUILayout.PropertyField(watchInteract);
            EditorGUILayout.PropertyField(delayedInteract);
            EditorGUI.indentLevel--;
        }

        EditorGUI.EndProperty();
    }
}