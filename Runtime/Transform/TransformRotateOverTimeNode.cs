using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode("Transform", "Transform: Rotate Over Time", "Transform:\n Rotate Over Time", nodeIcon = NodeIcons.time, nodeColor = NodeColors.green)]
    [System.Serializable]
    public class TransformRotateOverTimeNode : ActionNode
    {
        public NodeProperty<Vector3> rotation;
        public NodeProperty<float> rotationsPerSecond;
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
            
        }

        protected override State OnUpdate()
        {
            if (context.transform == null)
                state = State.Failure;
            else
            {
                context.transform.Rotate(rotationsPerSecond.Value * Time.deltaTime * rotation.Value);
                state = State.Success;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            description = $"Rotates the object {rotation.Value} degrees in each axis {rotationsPerSecond.Value} times per second.";

        }
    }
}