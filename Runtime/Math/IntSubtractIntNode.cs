namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Math/Integer", menuName = "Integer: Subtract Integer", nodeTitle = "Integer Math:\nSubtract Integer", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class IntSubtractIntNode : ActionNode
    {

        public NodeProperty<int> baseValue;
        public NodeProperty<int> subtractValue;
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