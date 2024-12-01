using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Input")]
    [NodeTitle("Input:\nOn Key Held")]
    [NodeMenuName("Input: On Key Held")] 
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