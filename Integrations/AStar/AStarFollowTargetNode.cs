using Halcyon.BT;
using Pathfinding;
using Pathfinding.RVO;
using UnityEngine;

namespace BehaviourTree.Integrations.AStar
{
    [BehaviourTreeNode(menuPath = "Integrations/A-Star", menuName = "A-Star: Follow Target",
        nodeTitle = "A-Star:\n Follow Target", nodeColor = NodeColors.green, nodeIcon = NodeIcons.ai)]
    public class AStarFollowTargetNode : ActionNode
    {
        public NodeProperty<Transform> transformToFollow;
        public override void OnInit()
        {
            context.AIPath = context.gameObject.GetComponent<AIPath>();
        }
        protected override void OnStart()
        {
            if (context.AIPath == null)
            {
                state = State.Failure;
                context.AIPath = context.gameObject.GetComponent<AIPath>();
            }
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
            if (state == State.Failure)
                return State.Failure;
        
            if((context.AIPath.destination - (transformToFollow.Value != null? transformToFollow.Value.position: context.transform.position)).magnitude < .25f)
            {
                return State.Success;
            }
            if (transformToFollow.Value != null)
                context.AIPath.destination = transformToFollow.Value.position;
            else
                context.AIPath.destination = context.transform.position;
            
            return State.Success;
        }
    }
}