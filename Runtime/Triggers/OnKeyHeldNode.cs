using UnityEngine;

namespace TheKiwiCoder
{
    
    [BehaviourTreeNode(menuFolder = "Triggers", nodeTitle = "On Key Held", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnKeyHeldNode : TriggerNode
    {

        public KeyCode keyCode;

        public override void OnInit()
        {
            context.behaviourTreeInstance.OnInputKey += CheckInput;
        }
        public override void OnDisable()
        {
            context.behaviourTreeInstance.OnInputKey -= CheckInput;
        }
        public void CheckInput()
        {

            if (Input.GetKey(keyCode))
                OnUpdate();
        }

    }
    
}