using UnityEditor;
using UnityEngine;
using System;

namespace Halcyon
{

    [CustomPropertyDrawer(typeof(ShowIfEnumAttribute))]
    public class ShowIfEnumDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ShowIfEnumAttribute showIf = (ShowIfEnumAttribute)attribute;
            SerializedProperty enumProperty = property.serializedObject.FindProperty(showIf.EnumFieldName);


            if (enumProperty != null && enumProperty.propertyType == SerializedPropertyType.Enum)
            {

                int enumValue = enumProperty.enumValueIndex;
                int expectedEnumValue = Convert.ToInt32(showIf.EnumValue);

                if (enumValue == expectedEnumValue)
                {
                    EditorGUI.PropertyField(position, property, label);
                }
            }
            else
            {
                EditorGUI.LabelField(position, $"[ShowIfEnum] Error: Could not find enum {showIf.EnumFieldName}");
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ShowIfEnumAttribute showIf = (ShowIfEnumAttribute)attribute;
            SerializedProperty enumProperty = property.serializedObject.FindProperty(showIf.EnumFieldName);

            if (enumProperty != null && enumProperty.propertyType == SerializedPropertyType.Enum)
            {
                int enumValue = enumProperty.enumValueIndex;
                int expectedEnumValue = Convert.ToInt32(showIf.EnumValue);

                return (enumValue == expectedEnumValue) ? EditorGUI.GetPropertyHeight(property, label) : 0;
            }

            return EditorGUI.GetPropertyHeight(property, label);
        }

        public bool HasFlag<T>(int value, T flag) where T : Enum
        {
            int flagInt = Convert.ToInt32(flag);
            return (value & flagInt) == flagInt;
        }

        public static bool HasFlag(int value, int flag)
        {
            return (value & flag) == flag;
        }
    }
}