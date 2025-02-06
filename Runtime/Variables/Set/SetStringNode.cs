namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nSet String")]
    [NodeMenuName("Variable: Set String")] 
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("BaseStringValue", BBVariableType.String)]
    [CreateBBVariable("SaveStringValue", BBVariableType.String)]
    [System.Serializable]
    public class SetStringNode : ActionNode
    {

        public NodeProperty<string> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<string> saveValue;
        
        
        
        
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