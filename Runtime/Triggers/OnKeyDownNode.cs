using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuFolder = "Triggers", nodeTitle = "On Key Down", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnKeyDownNode : TriggerNode
    {
        public KeyCode keyCode;
        
        public override void OnInit()
        {
            context.behaviourTreeInstance.OnInputKeyDown += CheckInput;
        }

        public override void OnDisable()
        {
            context.behaviourTreeInstance.OnInputKeyDown -= CheckInput;
        }

        public void CheckInput()
        {


            if (Input.GetKeyDown(keyCode))
            {
                OnUpdate();
                state = State.Success;
            }
        }

       

        
    }
}