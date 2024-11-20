using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Halcyon.BT
{
    [CustomPropertyDrawer(typeof(NumericProperty))]
    public class NumericPropertyDrawer : PropertyDrawer
    {
        private SerializedProperty intValueProp;
        private SerializedProperty floatValueProp;
        private SerializedProperty doubleValueProp;
        private SerializedProperty longValueProp;
        private SerializedProperty valueProp;
        private PropertyField valueField;
        
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            SerializedProperty parameterType = property.FindPropertyRelative("parameterType");
            
            PropertyField parameterField = new PropertyField();
            parameterField.label = property.displayName + " Type"; //parameterType.displayName;
            parameterField.style.flexGrow = 1.0f;
            parameterField.BindProperty(parameterType);
           
            intValueProp = property.FindPropertyRelative("integerValue");
            floatValueProp = property.FindPropertyRelative("floatValue");
            doubleValueProp = property.FindPropertyRelative("doubleValue");
            longValueProp = property.FindPropertyRelative("longValue"); 
            
            
            valueField = new PropertyField();
            SerializedProperty valueProperty = null;
            
            switch (parameterType.enumValueIndex)
            {
                case 0: 
                    valueProperty = intValueProp;
                    break;
                case 1:
                    valueProperty = floatValueProp;
                    break;
                case 2:
                    valueProperty = doubleValueProp;
                    break;
                case 3: 
                    valueProperty = longValueProp;
                    break;
            }
            
            valueField.label = valueProperty.displayName;
            valueField.style.flexGrow = 1.0f;
            
            valueField.BindProperty(valueProperty);
            
            valueField.style.marginBottom = 8;
            
            parameterField.RegisterValueChangeCallback(evt => 
            {
                UpdateValueProperty(parameterType.enumValueIndex);
            });
            
            VisualElement container = new VisualElement();
            container.AddToClassList("unity-base-field");
            container.AddToClassList("node-property-field");
            container.style.flexDirection = FlexDirection.Column;
            
            Label label = new Label();
            label.AddToClassList("unity-base-field__label");
            label.AddToClassList("unity-property-field__label");
            label.AddToClassList("unity-property-field");
            label.text = property.displayName; 
           
            //container.Add(label);
            container.Add(parameterField);
            container.Add(valueField);
            
            return container;
            
        }

        private void UpdateValueProperty(int index)
        {
            switch (index)
            {
                case 0: 
                    valueProp = intValueProp;
                    break;
                case 1:
                    valueProp = floatValueProp; 
                    break;
                case 2:
                    valueProp = doubleValueProp;
                    break;
                case 3: 
                    valueProp = longValueProp;
                    break;
            }
            valueField.BindProperty(valueProp);
        }
    }
}
