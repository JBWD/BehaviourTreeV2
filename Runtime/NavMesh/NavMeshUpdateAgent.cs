using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "NavMesh",menuName = "NavMesh: Update Agent", nodeTitle = "NavMesh:\n Update Agent", nodeColor = NodeColors.green)]
    [System.Serializable]
    public class NavMeshUpdateAgent : ActionNode {

        [Tooltip("How fast to move")]
        public NodeProperty<float> speed = new NodeProperty<float> { defaultValue = 5.0f };

        [Tooltip("Stop within this distance of the target")]
        public NodeProperty<float> stoppingDistance = new NodeProperty<float> { defaultValue = 0.1f };

        [Tooltip("Updates the agents rotation along the path")]
        public NodeProperty<bool> updateRotation = new NodeProperty<bool> { defaultValue = true };

        [Tooltip("Maximum acceleration when following the path")]
        public NodeProperty<float> acceleration = new NodeProperty<float> { defaultValue = 40.0f };
        
        protected override void OnStart()
        {
            if (context.agent != null)
            {
                context.agent.speed = speed.Value;
                context.agent.stoppingDistance = stoppingDistance.Value;
                context.agent.updateRotation = updateRotation.Value;
                context.agent.acceleration = acceleration.Value;
                state = State.Success;
            }
            else
            {
                state = State.Failure;
            }
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {



            return state;
            ;
        }
    }
}