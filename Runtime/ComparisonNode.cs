namespace Halcyon.BT
{
    [NodeColor(NodeColors.yellow)]
    [NodeIcon(NodeIcons.condition)]
    public abstract class ComparisonNode : DecoratorNode
    {
        public NodeProperty<bool> DesiredState = new NodeProperty<bool>(){Value = true};

        protected override State OnUpdate()
        {
            switch (CheckComparison())
            {
                case true:
                    child.Update();
                    return State.Success;
                default:
                    return State.Failure;
            }
        }

        public abstract bool CheckComparison();
    }
}