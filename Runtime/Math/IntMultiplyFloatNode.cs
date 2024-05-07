namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Math/Integer", menuName = "Integer: Multiply Float", nodeTitle = "Integer Math:\nMultiply Float", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class IntMultiplyFloatNode :ActionNode
    {

        public NodeProperty<int> baseValue;
        public NodeProperty<float> multiplyValue = new NodeProperty<float>(){Value = 1};
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
           
            saveValue.Value = (int)(baseValue.Value * multiplyValue.Value);
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