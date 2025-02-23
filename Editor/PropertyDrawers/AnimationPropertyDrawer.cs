using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Halcyon.BT
{
    [CustomPropertyDrawer(typeof(AnimationProperty))]
    public class AnimationPropertyDrawer : PropertyDrawer
    {
        /*public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
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
        }*/
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var root = new VisualElement();

            var parameterType = property.FindPropertyRelative("parameterType");
            var parameterTypeField = new PropertyField(parameterType);
            root.Add(parameterTypeField);
        
            var parameterNameField = new PropertyField(property.FindPropertyRelative("parameterName"));
            root.Add(parameterNameField);
        
            var booleanField = new PropertyField(property.FindPropertyRelative("booleanParameter"));
            var floatField = new PropertyField(property.FindPropertyRelative("floatParameter"));
            var integerField = new PropertyField(property.FindPropertyRelative("integerParameter"));

            root.Add(booleanField);
            root.Add(floatField);
            root.Add(integerField);

            // Update field visibility based on enum selection
            void UpdateVisibility()
            {
                booleanField.style.display = parameterType.enumValueIndex == 0 ? DisplayStyle.Flex : DisplayStyle.None;
                floatField.style.display = parameterType.enumValueIndex == 1 ? DisplayStyle.Flex : DisplayStyle.None;
                integerField.style.display = parameterType.enumValueIndex == 2 ? DisplayStyle.Flex : DisplayStyle.None;
            }

            // Initial update and register for changes
            UpdateVisibility();
            parameterTypeField.RegisterValueChangeCallback(evt =>
            {
                parameterType.serializedObject.ApplyModifiedProperties();
                UpdateVisibility();
            });
        
            return root;
        }
    }
}