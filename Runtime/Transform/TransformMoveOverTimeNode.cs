using System;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform")]
    [NodeTitle("Transform:\nMove Over Time")]
    [NodeMenuName("Transform: Move Over Time")]
    [NodeIcon(NodeIcons.time)]
    [CreateBBVariable("MovementSpeedDirection", BBVariableType.Vector3)]
    [Serializable]
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
                Debug.Log(movementSpeedDirection.Value);
                
                state = State.Success;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            description = $"Translates the object {movementSpeedDirection.Value} per second.";

        }
    }
}