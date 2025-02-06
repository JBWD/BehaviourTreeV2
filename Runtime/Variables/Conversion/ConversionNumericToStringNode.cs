namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nNumeric to String")]
    [NodeMenuName("Variable: Numeric to String")] 
    [NodeIcon(NodeIcons.repeat)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("NumericValue", BBVariableType.Number)]
    [CreateBBVariable("StringValue", BBVariableType.String)]

    [System.Serializable]
    public class ConversionNumericToStringNode : ActionNode
    {
        public NodeProperty<NumericProperty> numericValue;
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

            saveValue.Value = numericValue.Value.FloatValue.ToString();
            state =State.Success;

            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;
            
            if (saveValue.reference != null)
            {

                description =
                    $"Saves the string of 'FloatValue' in the 'SaveValue'.";
            }
            else
            {
                description = "Does not save the value";
                errored = true;
            }
            
        }
    }
}