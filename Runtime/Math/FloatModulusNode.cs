namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Math/Float", menuName = "Float: Modulus", nodeTitle = "Float Math:\n Modulus", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class FloatModulusNode :ActionNode
    {

        public NodeProperty<float> baseValue;
        public NodeProperty<int> modulusValue = new NodeProperty<int>(){Value = 1};
        public NodeProperty<float> saveValue;


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