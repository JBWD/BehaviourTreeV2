using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Halcyon {
    [CustomEditor(typeof(BehaviourTreeRunner))]
    public class BehaviourTreeInstanceEditor : Editor {

        public override VisualElement CreateInspectorGUI() {

            VisualElement container = new VisualElement();

            PropertyField treeField = new PropertyField();
            treeField.bindingPath = nameof(BehaviourTreeRunner.behaviourTree);

            PropertyField validateField = new PropertyField();
            validateField.bindingPath = nameof(BehaviourTreeRunner.validate);

            PropertyField publicKeys = new PropertyField();
            publicKeys.bindingPath = nameof(BehaviourTreeRunner.blackboardOverrides);

            container.Add(treeField);
            container.Add(validateField);
            container.Add(publicKeys);

            return container;
        }
    }
}
