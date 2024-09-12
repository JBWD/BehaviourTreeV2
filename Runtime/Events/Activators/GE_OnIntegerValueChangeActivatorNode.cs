namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Global Events/Activator", menuName = "Event Activator: On Integer Change",
        nodeTitle = "Event Activator:\nOn Integer Change", nodeColor = NodeColors.grey, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public class GE_OnIntegerValueChangeActivatorNode : ActionNode
    {

        public NodeProperty<string> activationName;
        public NodeProperty<int> activationValue;

        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            GlobalEvents.OnIntegerValueChange?.Invoke(activationName.Value, activationValue.Value);
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