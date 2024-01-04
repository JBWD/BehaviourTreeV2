namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Math/Float", menuName = "Subtract Float", nodeTitle = "Float Math:\nSubtract Float", nodeColor = NodeColors.green, nodeIcon = NodeIcons.action)]
    [System.Serializable]
    public class FloatSubtractFloatNode : ActionNode
    {

        public NodeProperty<float> baseValue;
        public NodeProperty<float> subtractValue;
        public NodeProperty<float> saveValue;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveValue.Value = baseValue.Value - subtractValue.Value;
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;
            try
            {
                if (saveValue.reference != null)
                {
                    
                    description =
                        $"Subtracts '{baseValue.Value}' - '{subtractValue.Value}' and saves the total in '{saveValue.reference.name}'";
                }
                else
                {
                    description = "Does not save the value";
                    errored = true;
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}