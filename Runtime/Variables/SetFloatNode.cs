namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Variable",menuName = "Variable: Set Float", nodeTitle = "Variables:\nSet Float",
        nodeIcon = NodeIcons.save, nodeColor = NodeColors.pink)]
    [System.Serializable]
    public class SetFloatNode : ActionNode
    {

        public NodeProperty<float> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<float> saveValue;
        
        
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        
        protected override State OnUpdate()
        {
            saveValue.Value = baseValue.Value;
            state = State.Success;
            return state;
        }
        public override void UpdateDescription()
        {
            errored = false;
            if (saveValue.reference == null)
            {
                description = "Does not save any of the values";
                errored = true;
            }
            else
            {
                description = "Sets the 'SaveValue' to the same value or reference as 'BaseValue'";
            }
        }
    }
}