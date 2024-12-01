namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Variable", menuName = "Variable: Compare Booleans",
        nodeTitle = "Variables:\nCompare Booleans",
        nodeIcon = NodeIcons.condition, nodeColor = NodeColors.yellow)]
    [System.Serializable]
    public class ComparisonBooleanNode : DecoratorNode
    {
        public NodeProperty<bool> firstValue;
        public NodeProperty<bool> secondValue;


        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }


        protected override State OnUpdate()
        {
            if (firstValue.Value == secondValue.Value)
            {
                state = State.Success;
                if(child != null)
                    child.Update();
            }
            else
            {
                state = State.Failure;
            }

            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;
            description = "Checks to see if the boolean values are equal to each other.";

        }
    }
}