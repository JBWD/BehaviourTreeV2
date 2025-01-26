using UnityEngine;

namespace Halcyon.BT
{

    [NodeTitle("NavMesh:\n Follow Target")]
    [NodeMenuName("NavMesh: Follow Target")]
    [NodeMenuPath("NavMesh")]
    [NodeIcon(NodeIcons.ai)]
    [CreateBBVariable("TransformToFollow", BBVariableType.Transform)]
    [CreateBBVariable("RecalculationDistance", BBVariableType.Number)]
    [System.Serializable]
    public class NavMeshFollowTarget : ActionNode
    {
        
        [Tooltip("Transform the Navmesh will try to follow or move close to.")]
        [BlackboardValueOnly]
        public NodeProperty<Transform> transformToFollow;

        [Tooltip("Distance between this object and the target to which the path will be recalculated.")]
        public NodeProperty<NumericProperty> recalculationDistance = new NodeProperty<NumericProperty>() {Value =  new NumericProperty(){DoubleValue = 1}};
        
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

            
            if(Vector3.Distance(transformToFollow.Value.position, context.transform.position) > recalculationDistance.Value.FloatValue)
                context.agent.SetDestination(transformToFollow.Value.position);
            
            return state = State.Success;
        }
    }
}