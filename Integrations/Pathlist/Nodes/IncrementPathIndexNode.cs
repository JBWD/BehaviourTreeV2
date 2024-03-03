namespace Halcyon.Integrations.Pathlist
{
    [BehaviourTreeNode(menuPath = "Integrations/PathList", menuName = "PathList: Increment Index", nodeTitle = "PathList:\nIncrement Index", nodeColor = NodeColors.green, nodeIcon = NodeIcons.destination)]
    [System.Serializable]
    public class IncrementPathIndexNode : ActionNode
    {
        

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
                context.pathlist.index ++;
                state = State.Success;
            }

            return state;
        }
    }
}