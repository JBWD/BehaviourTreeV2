using UnityEngine;

namespace Halcyon.BT.Integrations.Pathlist
{
    [BehaviourTreeNode(menuPath = "Integrations/PathList", menuName = "PathList: Add Position", nodeTitle = "PathList:\nAdd Position", nodeColor = NodeColors.green, nodeIcon = NodeIcons.destination)]
    [System.Serializable]
    public class AddPathPositionNode : ActionNode
    {
        public NodeProperty<Vector3> positionValue;
        
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
                context.pathlist.AddPathPosition(positionValue.Value);
                state = State.Success;
            }

            return state;
        }
        
    }
}