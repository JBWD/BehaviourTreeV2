namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Math/Float", menuName = "Multiply Float", nodeTitle = "Float Math:\nMultiply Float", nodeColor = NodeColors.green, nodeIcon = NodeIcons.action)]
    [System.Serializable]
    public class FloatMultiplyFloatNode :ActionNode
    {

        public NodeProperty<float> baseValue;
        public NodeProperty<float> multiplyValue = new NodeProperty<float>(){Value = 1};
        public NodeProperty<float> saveValue;


        protected override void OnStart()
        {
           
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
           
            saveValue.Value = baseValue.Value * multiplyValue.Value;
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            try
            {
                errored = false;
                if (saveValue.reference != null)
                {
                    description =
                        $"Multiplies '{baseValue.Value}' * '{multiplyValue.Value}' and saves the total in '{saveValue.reference.name}'";
                }
                else
                {
                    description =
                        $"Does not save the value";
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