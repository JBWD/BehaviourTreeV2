namespace Halcyon.BT
{
    
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.save)]
    [NodeTitle("Variable:\nSet Integer")]
    [NodeMenuPath("Variable/Set")]
    [NodeMenuName("Variable: Set Integer")]
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