namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nSet Numeric")]
    [NodeMenuName("Variable: Set Numeric")] 
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("BaseNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveNumericValue", BBVariableType.Number)]
    [System.Serializable]
    public class SetNumericNode : ActionNode
    {

        public NodeProperty<NumericProperty> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<NumericProperty> saveValue;
        
        
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        
        protected override State OnUpdate()
        {
            saveValue.Value.DoubleValue = baseValue.Value.DoubleValue;
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