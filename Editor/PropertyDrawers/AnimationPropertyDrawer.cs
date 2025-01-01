﻿using UnityEditor;
using UnityEngine;

namespace Halcyon.BT
{
    [CustomPropertyDrawer(typeof(AnimationProperty))]
    public class AnimationPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var parameterType = property.FindPropertyRelative("parameterType");
            
            EditorGUILayout.PropertyField(parameterType);
            EditorGUILayout.PropertyField(property.FindPropertyRelative("parameterName"));
            switch (parameterType.enumValueIndex)
            {
                case 0:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("booleanParameter"));
                    break;
                case 1:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("floatParameter"));
                    break;
                case 2:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("integerParameter"));
                    break;
                default:
                    break;
                
                
            }
        }
    }
}