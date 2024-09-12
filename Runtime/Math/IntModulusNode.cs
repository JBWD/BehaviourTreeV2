namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Math/Integer", menuName = "Integer: Modulus", nodeTitle = "Integer Math:\n Modulus", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class IntModulusNode :ActionNode
    {

        public NodeProperty<int> baseValue;
        public NodeProperty<int> modulusValue = new NodeProperty<int>(){Value = 1};
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
           
            saveValue.Value = baseValue.Value % modulusValue.Value;
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
                        $"Modulus '{baseValue.Value}' % '{modulusValue.Value}' and saves the remainder in '{saveValue.reference.name}'";
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