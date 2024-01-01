using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuFolder = "Triggers", nodeTitle = "On Key Up", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
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