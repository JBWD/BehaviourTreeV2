namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Variable/Conversion", menuName = "Conversion: Float to String", 
        nodeTitle = "Conversion:\nFloat to String", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.repeat)]

    [System.Serializable]
    public class ConversionFloatToStringNode : ActionNode
    {
        public NodeProperty<float> floatValue;
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

            saveValue.Value = floatValue.Value.ToString();
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