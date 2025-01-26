using UnityEngine;

namespace Halcyon.BT
{
    
    [NodeTitle("NavMesh AI:\n Run State Listener")]
    [NodeMenuName("NavMesh AI: Run State Listener")]
    [NodeMenuPath("NavMesh")]
    [NodeColor(NodeColors.white)]
    public class NavMeshAIRunStateListenerNode : TriggerNode
    {

        public NodeProperty<AIStates> desiredState;
        
        public override void OnInit()
        {
            context.OnStateChange += ChangeState;
        }
        
        protected override State OnUpdate() {
            
            
            if (child != null)
            {
                state = child.Update();
                
            } else
            {
                state = State.Failure;
            }
            return state;
        }


        public void ChangeState(AIStates newState)
        {
            if (desiredState.Value == newState)
            {
                OnUpdate();
            }
        }
    }
}