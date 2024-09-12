namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Global Events/Activator", menuName = "Event Activator: On String Change",
        nodeTitle = "Event Activator:\nOn String Change", nodeColor = NodeColors.grey, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public class GE_OnStringValueChangeActivatorNode : ActionNode
    {

        public NodeProperty<string> activationName;
        public NodeProperty<string> activationValue;

        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            GlobalEvents.OnStringValueChange.Invoke(activationName.Value, activationValue.Value);
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            description =
                $"Activates a value change event for {activationName.Value} and sends the value: {activationValue.Value}";
        }
    }
}