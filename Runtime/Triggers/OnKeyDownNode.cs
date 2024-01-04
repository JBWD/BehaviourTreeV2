using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Triggers/Input", nodeTitle = "On Key Down", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.input)]
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