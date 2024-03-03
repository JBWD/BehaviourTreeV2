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

        public override void UpdateDescription()
        {
            description =
                "When the specified InputKey is held, all children nodes are invoked, this does not repeat like the main loop.";
        }        
        
    }
    
    
    
}