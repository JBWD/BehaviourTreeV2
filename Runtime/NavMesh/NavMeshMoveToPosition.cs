using System.Threading;
using System.Threading.Tasks;
using UnityEngine;



namespace Halcyon {

    [BehaviourTreeNode(menuPath = "NavMesh",menuName = "NavMesh: Move To Position", nodeTitle = "NavMesh:\n Move To Position", nodeColor = NodeColors.green)]
    [System.Serializable]
    public class NavMeshMoveToPosition : ActionNode {

        
        [Tooltip("Target Position")]
        public NodeProperty<Vector3> targetPosition = new NodeProperty<Vector3> { defaultValue = Vector3.zero };



        protected override void OnStart()
        {
        }

        protected override void OnStop() {
            if (context.agent.pathPending) {
                context.agent.ResetPath();
            }
            
        }

        protected override State OnUpdate() {
            if (context.agent == null) {
                Debug.Log($"Game object {context.gameObject.name} is missing NavMeshAgent component");
                return state =State.Failure;
            }

            if (!context.agent.enabled) {
                Debug.Log($"NavMeshAgent component on {context.gameObject.name} was disabled");
                return state =State.Failure;
            }


            if (targetPosition.Value != context.agent.destination)
            {
                context.agent.SetDestination(targetPosition.Value);
            }
            else if (context.agent.remainingDistance < context.agent.stoppingDistance)
            {
                return state = State.Success;
            }

            return state =State.Running;
        }
        
        public override void OnDrawGizmos() {
            var agent = context.agent;
            var transform = context.transform;

            // Current velocity
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + agent.velocity);

            // Desired velocity
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + agent.desiredVelocity);

            // Current path
            Gizmos.color = Color.black;
            var agentPath = agent.path;
            Vector3 prevCorner = transform.position;
            foreach (var corner in agentPath.corners) {
                Gizmos.DrawLine(prevCorner, corner);
                Gizmos.DrawSphere(corner, 0.1f);
                prevCorner = corner;
            }
        }
    }
}
