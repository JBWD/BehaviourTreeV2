using UnityEngine;

namespace Halcyon
{
    
    [BehaviourTreeNode(menuPath = "Triggers & Events/Input", menuName = "Input: On Key Held", nodeTitle = "Input:\nOn Key Held", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.input)]
    [System.Serializable]
    public class OnKeyHeldNode : TriggerNode
    {

        public KeyCode keyCode;

        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnInputKey += CheckInput;
        }
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnInputKey -= CheckInput;
        }
        public void CheckInput()
        {

            if (Input.GetKey(keyCode))
                OnUpdate();
        }

    }
    
}