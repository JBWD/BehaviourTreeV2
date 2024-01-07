using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Transform/OverTime", "Transform: Move Over Time", "Transform:\nMove Over Time", nodeIcon = NodeIcons.time, nodeColor = NodeColors.green)]
    public class TransformMoveOverTimeNode : ActionNode
    {

        public NodeProperty<Vector3> movementSpeedDirection;



        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (context.transform == null)
            {
                state = State.Failure;
            }
            else
            {
                context.transform.Translate(Time.deltaTime * movementSpeedDirection.Value);
                
                
                state = State.Success;
            }

            return state;
        }
    }
}