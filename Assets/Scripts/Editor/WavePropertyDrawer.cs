using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Wave))]
public class WavePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var populatorRect = new Rect(position.x, position.y, position.width - 90, position.height);
        var boidsCountRect = new Rect(position.x + position.width - 85, position.y, 40, position.height);
        var secondsRect = new Rect(position.x + position.width - 40, position.y, 40, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(populatorRect, property.FindPropertyRelative("populator"), GUIContent.none);
        EditorGUI.PropertyField(boidsCountRect, property.FindPropertyRelative("boidsCount"), GUIContent.none);
        EditorGUI.PropertyField(secondsRect, property.FindPropertyRelative("seconds"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
