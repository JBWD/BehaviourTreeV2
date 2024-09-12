using UnityEngine;

namespace Halcyon.BT.Integrations.Pathlist
{
    [BehaviourTreeNode(menuPath = "Integrations/PathList", menuName = "PathList: Get Position", nodeTitle = "PathList:\nGet Position", nodeColor = NodeColors.green, nodeIcon = NodeIcons.destination)]
    [System.Serializable]
    public class GetCurrentPositionNode : ActionNode
    {
        
        public NodeProperty<Vector3> savePosition;
        
        public override void OnInit()
        {
            context.InitializePathList();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (context.pathlist == null)
            {
                state = State.Failure;
            }
            else
            {
                savePosition.Value = context.pathlist.GetCurrentPosition();
                state = State.Success;
            }

            return state;
        }
    }
}