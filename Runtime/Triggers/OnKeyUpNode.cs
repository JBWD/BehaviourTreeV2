using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Input", menuName = "Input: On Key Up", nodeTitle = "Input:\nOn Key Up", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.input)]
    [System.Serializable]
    public class OnKeyUpNode : TriggerNode
    {
        public KeyCode keyCode;
        
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnInputKeyUp += CheckInput;
        }
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnInputKeyUp -= CheckInput;
        }
        public void CheckInput()
        {
            
            if (Input.GetKeyUp(keyCode))
            {
                OnUpdate();
            }
        }

        
        public override void UpdateDescription()
        {
            description =
                "When the specified InputKeyUp occurs, all children nodes are invoked, this does not repeat like the main loop.";
        }
    }
}