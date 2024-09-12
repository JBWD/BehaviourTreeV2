namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "GameObject/Get", menuName = "GameObject: Get Tag", nodeColor = NodeColors.pink,
        nodeIcon = NodeIcons.none, nodeTitle = "GameObject:\nGet Tag")]
    [System.Serializable]
    public class GetGameObjectTagNode :ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<string> tagValue;
        
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
                tagValue.Value = context.gameObject.tag;
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
            
            description = $"Retrieves the gameObjects tag and saves it in [TagValue].";
        }
    }
}