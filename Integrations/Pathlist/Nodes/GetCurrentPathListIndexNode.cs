using UnityEngine;

namespace TheKiwiCoder.Integrations.Pathlist
{
    [BehaviourTreeNode(menuPath = "Integrations/PathList", menuName = "PathList: Get Index", nodeTitle = "PathList:\nGet Index", nodeColor = NodeColors.green, nodeIcon = NodeIcons.destination)]
    [System.Serializable]
    public class GetCurrentPathListIndexNode : ActionNode
    {
        public NodeProperty<int> saveIndex;
       
        
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
                saveIndex.Value = context.pathlist.index;
                state = State.Success;
            }

            return state;
        }
    }
}