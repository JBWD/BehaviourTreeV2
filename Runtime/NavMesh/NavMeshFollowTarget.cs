using UnityEngine;

namespace Halcyon
{

    [BehaviourTreeNode(menuPath = "NavMesh", menuName = "NavMesh: Follow Target", nodeTitle = "NavMesh:\n Follow Target")]
    [System.Serializable]
    public class NavMeshFollowTarget : ActionNode
    {
        
        [Tooltip("Transform the Navmesh will try to follow or move close to.")]
        [BlackboardValueOnly]
        public NodeProperty<Transform> transformToFollow;

        [Tooltip("Distance between this object and the target to which the path will be recalculated.")] 
        public float recalcDistance = 1f;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (transformToFollow?.Value == null)
            {
                context.agent.SetDestination(context.transform.position);
                return state = State.Failure;
            }

            if(context.agent == null)
                return state = State.Failure;

            
            if(Vector3.Distance(transformToFollow.Value.position, context.transform.position) > recalcDistance)
                context.agent.SetDestination(transformToFollow.Value.position);
            
            return state = State.Success;
        }
    }
}