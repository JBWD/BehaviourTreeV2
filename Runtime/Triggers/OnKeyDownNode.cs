using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers/Input", menuName = "Input: On Key Down", nodeTitle = "Input:\nOn Key Down", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.input)]
    public class OnKeyDownNode : TriggerNode
    {
        public KeyCode keyCode;
        
        
        
        
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnInputKeyDown += CheckInput;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnInputKeyDown -= CheckInput;
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