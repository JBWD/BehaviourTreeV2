using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Input")]
    [NodeTitle("Input:\nOn Key Down")]
    [NodeMenuName("Input: On Key Down")] 
    [System.Serializable]
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

        public override void UpdateDescription()
        {
            description =
                "When the specified InputKeyDown occurs, all children nodes are invoked, this does not repeat like the main loop.";
        }

        
    }
}