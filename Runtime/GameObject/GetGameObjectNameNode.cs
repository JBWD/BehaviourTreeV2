namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "GameObject/Get", menuName = "GameObject: Get Name", nodeColor = NodeColors.pink,
        nodeIcon = NodeIcons.none, nodeTitle = "GameObject:\nGet Name")]

    [System.Serializable]
    public class GetGameObjectNameNode: ActionNode
    {
        public NodeProperty<string> nameValue;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (context.gameObject != null)
            {
                nameValue.Value = context.gameObject.name;
                state = State.Success;
            }
            else
            {
                state = State.Failure;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            
            description = $"Retrieves the gameObjects name and saves it in [NameValue].";
        }
    }
}