namespace Halcyon.BT.Integrations.Pathlist
{
    [BehaviourTreeNode(menuPath = "Integrations/PathList", menuName = "PathList: Set Index", nodeTitle = "PathList:\nSet Index", nodeColor = NodeColors.green, nodeIcon = NodeIcons.destination)]
    [System.Serializable]
    public class SetPathListIndexNode : ActionNode
    {
        public NodeProperty<int> index;

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
                context.pathlist.index = index.Value;
                state = State.Success;
            }

            return state;
        }
    }
}