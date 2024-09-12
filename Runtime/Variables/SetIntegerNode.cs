namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Variable",menuName = "Variable: Set Integer", nodeTitle = "Variables:\nSet Integer",
        nodeIcon = NodeIcons.save, nodeColor = NodeColors.pink)]
    [System.Serializable]
    public class SetIntegerNode : ActionNode
    {

        public NodeProperty<int> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<int> saveValue;
        
        
        
        
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