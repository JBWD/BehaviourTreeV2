using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Input")]
    [NodeTitle("Input:\nOn Key Up")]
    [NodeMenuName("Input: On Key Up")] 
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