using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Halcyon {
    [CustomEditor(typeof(BehaviourTreeRunner))]
    public class BehaviourTreeInstanceEditor : Editor
    {

        public int currentCount = 0;
        
        public override VisualElement CreateInspectorGUI() {
            
            VisualElement container = new VisualElement();

            PropertyField treeField = new PropertyField();
            treeField.bindingPath = nameof(BehaviourTreeRunner.behaviourTree);

            PropertyField validateField = new PropertyField();
            validateField.bindingPath = nameof(BehaviourTreeRunner.validate);

            PropertyField publicKeys = new PropertyField();
            publicKeys.bindingPath = nameof(BehaviourTreeRunner.blackboardOverrides);
            BehaviourTreeRunner runner = target as BehaviourTreeRunner;
            currentCount = runner.blackboardOverrides.Count;
            publicKeys.RegisterValueChangeCallback((x)=>CheckCurrentCount());
            
            
            container.Add(treeField);
            container.Add(validateField);
            container.Add(publicKeys);
          
            
            return container;
        }

        public void CheckCurrentCount()
        {
            BehaviourTreeRunner runner = target as BehaviourTreeRunner;

            for (int i = currentCount; i < runner.blackboardOverrides.Count; i++)
            {
                runner.blackboardOverrides[i].value = default;
                
            }

            currentCount = runner.blackboardOverrides.Count;
        }

        public override bool RequiresConstantRepaint() => true;

    }
}
