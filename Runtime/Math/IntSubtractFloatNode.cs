namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Math/Integer", menuName = "Integer: Subtract Float", nodeTitle = "Integer Math:\nSubtract Float", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class IntSubtractFloatNode : ActionNode
    {

        public NodeProperty<int> baseValue;
        public NodeProperty<float> subtractValue;
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
            saveValue.Value = (int)(baseValue.Value - subtractValue.Value);
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