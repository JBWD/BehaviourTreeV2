using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Triggers/Input", nodeTitle = "On Key Up", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.input)]
    public class OnKeyUpNode : TriggerNode
    {
        public KeyCode keyCode;
        
        public override void OnInit()
        {
            context.behaviourTreeInstance.OnInputKeyUp += CheckInput;
        }
        public override void OnDisable()
        {
            context.behaviourTreeInstance.OnInputKeyUp -= CheckInput;
        }
        public void CheckInput()
        {
            
            if (Input.GetKeyUp(keyCode))
            {
                OnUpdate();
            }
        }

    }
}