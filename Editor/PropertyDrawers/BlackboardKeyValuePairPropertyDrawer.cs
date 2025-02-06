using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;

namespace Halcyon.BT {

    [CustomPropertyDrawer(typeof(BlackboardKeyValuePair))]
    public class BlackboardKeyValuePairPropertyDrawer : PropertyDrawer {

        VisualElement pairContainer;

        BehaviourTree GetBehaviourTree(SerializedProperty property) {
            if (property.serializedObject.targetObject is BehaviourTree tree) {
                return tree;
            } else if (property.serializedObject.targetObject is BehaviourTreeRunner instance) {
                return instance.RuntimeTree;
            }
            Debug.LogError("Could not find behaviour tree this is referencing");
            return null;
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            try
            {
                SerializedProperty first = property.FindPropertyRelative(nameof(BlackboardKeyValuePair.key));
                SerializedProperty second = property.FindPropertyRelative(nameof(BlackboardKeyValuePair.value));

                PopupField<BlackboardKey> dropdown = new PopupField<BlackboardKey>();
                dropdown.label = first.displayName;
                dropdown.formatListItemCallback = FormatItem;
                dropdown.formatSelectedValueCallback = FormatItem;
                dropdown.value = first.managedReferenceValue as BlackboardKey;

                BehaviourTree tree = GetBehaviourTree(property);


                dropdown.RegisterCallback<MouseEnterEvent>((evt) =>
                {
                    try
                    {
                        dropdown.choices.Clear();
                        foreach (var key in tree.blackboard.keys)
                        {
                            dropdown.choices.Add(key);
                        }
                    }
                    catch
                    {
                        
                    }

                });



                dropdown.RegisterCallback<ChangeEvent<BlackboardKey>>((evt) =>
                {
                    try
                    {
                        BlackboardKey newKey = evt.newValue;
                        first.managedReferenceValue = newKey;
                        property.serializedObject.ApplyModifiedProperties();

                        if (pairContainer.childCount > 1)
                        {
                            pairContainer.RemoveAt(1);
                        }

                        if (second.managedReferenceValue == null ||
                            second.managedReferenceValue.GetType() != dropdown.value.GetType())
                        {
                            second.managedReferenceValue = BlackboardKey.CreateKey(dropdown.value.GetType());
                            second.serializedObject.ApplyModifiedProperties();
                        }

                        PropertyField field = new PropertyField();
                        field.label = second.displayName;
                        field.BindProperty(second.FindPropertyRelative(nameof(BlackboardKey<object>.value)));
                        pairContainer.Add(field);
                    }
                    catch
                    {
                    }
                });

                pairContainer = new VisualElement();
                pairContainer.Add(dropdown);

                if (dropdown.value != null)
                {
                    if (second.managedReferenceValue == null || first.managedReferenceValue.GetType() !=
                        second.managedReferenceValue.GetType())
                    {
                        second.managedReferenceValue = BlackboardKey.CreateKey(dropdown.value.GetType());
                        second.serializedObject.ApplyModifiedProperties();
                    }

                    PropertyField field = new PropertyField();
                    field.label = second.displayName;
                    field.bindingPath = nameof(BlackboardKey<object>.value);
                    pairContainer.Add(field);
                }
            }
            catch
            {
            }

            return pairContainer;
        }

        private string FormatItem(BlackboardKey item) {
            if (item == null) {
                return "(null)";
            } else {
                return item.name;
            }
        }


    }
}
