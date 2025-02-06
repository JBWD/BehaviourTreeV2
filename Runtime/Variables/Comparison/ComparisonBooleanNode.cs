namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nCompare Booleans")]
    [NodeMenuName("Variable: Compare Booleans")] 
    [CreateBBVariable("FirstBooleanValue", BBVariableType.Boolean)]
    [CreateBBVariable("SecondBooleanValue", BBVariableType.Boolean)]
    [System.Serializable]
    public class ComparisonBooleanNode : ComparisonNode
    {
        public NodeProperty<bool> firstValue;
        public NodeProperty<bool> secondValue;


        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }
        
        public override bool CheckComparison()
        {
            return (firstValue.Value == secondValue.Value);
        }

        public override void UpdateDescription()
        {
            errored = false;
            description = "Checks to see if the boolean values are equal to each other.";

        }
    }
}