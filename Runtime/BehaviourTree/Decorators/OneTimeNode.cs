namespace Halcyon
{
    [System.Serializable]
    [BehaviourTreeNode(menuPath = "Behaviour Tree/Flow", nodeColor = NodeColors.blue)]
    public class OneTimeNode : DecoratorNode
    {
        private bool nodeRan = false;
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (nodeRan)
            {
                state = State.Success;
                return state;
            }

            nodeRan = true;
            state = child.Update();
            return state;

        }
    }
}