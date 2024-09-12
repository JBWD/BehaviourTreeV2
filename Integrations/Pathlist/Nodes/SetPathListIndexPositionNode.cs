using UnityEngine;

namespace Halcyon.BT.Integrations.Pathlist
{
    [BehaviourTreeNode(menuPath = "Integrations/PathList", menuName = "PathList: Set Position @ Index", nodeTitle = "PathList:\nSet Position @ Index", nodeColor = NodeColors.green, nodeIcon = NodeIcons.destination)]
    [System.Serializable]
    public class SetPathListIndexPositionNode : ActionNode
    {
        public NodeProperty<int> index;
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
                context.pathlist.SetPathPosition(index.Value,savePosition.Value);
                state = State.Success;
            }

            return state;
        }
    }
}