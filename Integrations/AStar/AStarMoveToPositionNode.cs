using System;
using Halcyon.BT;
using Pathfinding;
using UnityEngine;

namespace BehaviourTree.Integrations.AStar
{
    [BehaviourTreeNode(menuPath = "Integrations/A-Star", menuName = "A-Star: Move to Position",
        nodeTitle = "A-Star:\n Move to Position", nodeColor = NodeColors.green, nodeIcon = NodeIcons.ai)]
    public class AStarMoveToPositionNode : ActionNode
    {

        public NodeProperty<Vector3> DestinationPosition;

        public override void OnInit()
        {
            context.AIPath = context.gameObject.GetComponent<AIPath>();
        }


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if ((context.AIPath.destination - DestinationPosition.Value).magnitude < .25f)
            {
                return State.Success;
            }

            context.AIPath.destination = DestinationPosition.Value;
            return State.Success;
        }
    }
}