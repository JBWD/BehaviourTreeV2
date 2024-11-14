using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace Halcyon.BT {
    [UxmlElement]
    public partial class BlackboardView : VisualElement {

        //public new class UxmlFactory : UxmlFactory<BlackboardView, VisualElement.UxmlTraits> { }

        private SerializedBehaviourTree behaviourTree;
        private ListView listView;
        private TextField newKeyTextField;
        private PopupField<Type> newKeyTypeField;
        private Button createButton;
        private ObjectField blackboardTemplateField;
        internal void Bind(SerializedBehaviourTree behaviourTree) {
            
            this.behaviourTree = behaviourTree;

            listView = this.Q<ListView>("ListView_Keys");
            newKeyTextField = this.Q<TextField>("TextField_KeyName");
            VisualElement popupContainer = this.Q<VisualElement>("PopupField_Placeholder");
            
            createButton = this.Q<Button>("Button_KeyCreate");
            blackboardTemplateField = this.Q<ObjectField>("Blackboard_Template_Field");

            // ListView
            listView.Bind(behaviourTree.serializedObject);

            newKeyTypeField = new PopupField<Type>();
            newKeyTypeField.label = "Type";
            newKeyTypeField.formatListItemCallback = FormatItem;
            newKeyTypeField.formatSelectedValueCallback = FormatItem;

            var types = TypeCache.GetTypesDerivedFrom<BlackboardKey>();
            List<string> names = new List<string>();
            foreach (var type in types)
            {
                names.Add(type.ToString());
            }
            names.Sort();
            
            foreach (var itemName in names)
            {
                foreach(var type in types) {
                    if (type.IsGenericType || itemName != type.ToString()) {
                        continue;
                    }
                    newKeyTypeField.choices.Add(type);
                    if (newKeyTypeField.value == null) {
                        newKeyTypeField.value = type;
                    }
                }
            }
            
            
            popupContainer.Clear();
            popupContainer.Add(newKeyTypeField);

            // TextField
            newKeyTextField.RegisterCallback<ChangeEvent<string>>((evt) => {
                ValidateButton();
            });

            // Button
            createButton.clicked -= CreateNewKey;
            createButton.clicked += CreateNewKey;

            blackboardTemplateField.SetValueWithoutNotify(null);
            blackboardTemplateField.RegisterValueChangedCallback(evt =>
            {
                var template = evt.newValue as BlackboardTemplateSO;
                AddTemplateInformation(template);
            });
            ValidateButton();
        }

        private void AddTemplateInformation(BlackboardTemplateSO template)
        {
            if (template == null)
                return;
            foreach (var item in template.variables)
            {
                CreateNewKey(item.name, GetKeyType(item.type.type));
            }
            blackboardTemplateField.SetValueWithoutNotify(null);
        }

        private Type GetKeyType(string itemType)
        {
            Dictionary<string,Type> names = new Dictionary<string, Type>();
            var types = TypeCache.GetTypesDerivedFrom<BlackboardKey>();
            
            for (var index = 0; index < types.Count; index++)
            {
                var type = types[index];
                if (type.IsAbstract)
                    continue;
                string stringType = type.ToString();
                string[] n = stringType.Split('.');
                stringType = n[n.Length - 1].Replace("Key", "");
                names.Add(stringType,type);
                
            }

            if (names.ContainsKey(itemType))
            {
                return names[itemType];
            }

            return null;

        }

        private string FormatItem(Type arg) {
            if (arg == null) {
                return "(null)";
            } else {
                return arg.Name.Replace("Key", "");
            }
        }

        private void ValidateButton() {
            // Disable the create button if trying to create a non-unique key
            bool isValidKeyText = ValidateKeyText(newKeyTextField.text);
            createButton.SetEnabled(isValidKeyText);
        }

        bool ValidateKeyText(string text) {
            if (text == "") {
                return false;
            }

            BehaviourTree tree = behaviourTree.Blackboard.serializedObject.targetObject as BehaviourTree;
            bool keyExists = tree.blackboard.Find(newKeyTextField.text) != null;
            return !keyExists;
        }

        void CreateNewKey() {
            Type newKeyType = newKeyTypeField.value;
            if (newKeyType != null) {
                behaviourTree.CreateBlackboardKey(newKeyTextField.text, newKeyType);
            }
            ValidateButton();
        }

        void CreateNewKey(string name, Type type)
        {
            if (ValidateKeyText(name) || type == null)
                return;
            behaviourTree.CreateBlackboardKey(name,type);
        }

        public void ClearView() {
            this.behaviourTree = null;
            if (listView != null) {
                listView.Unbind();
            }
        }

      
    }
}