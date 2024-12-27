using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Halcyon.BT
{
    [CustomPropertyDrawer(typeof(NumericProperty))]
    public class NumericPropertyDrawer : PropertyDrawer
    {

        private SerializedProperty doubleValueProp;
        private PropertyField valueField;
        
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            doubleValueProp = property.FindPropertyRelative("doubleValue");
            
            valueField = new PropertyField();
            valueField.BindProperty(doubleValueProp);

         
            valueField.label = "";
            valueField.style.flexGrow = 1.0f;
 
            VisualElement container = new VisualElement();
            container.AddToClassList("unity-base-field");
            container.AddToClassList("node-property-field");
            container.style.flexDirection = FlexDirection.Column;
            
            Label label = new Label();
            label.AddToClassList("unity-base-field__label");
            label.AddToClassList("unity-property-field__label");
            label.AddToClassList("unity-property-field");
            label.text = property.displayName; 
            
            container.Add(valueField);
            
            return container;
            
        }
        
    }
}
