namespace Halcyon.BT
{
    
    [NodeColor(NodeColors.grey)]
    [NodeIcon(NodeIcons.trigger)]
    [NodeTitle("Event Activator:\nOn Integer Change")]
    [NodeMenuPath("Triggers & Events/Global Events/Activator")]
    [NodeMenuName("Event Activator: On Integer Change")]
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