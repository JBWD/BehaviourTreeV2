namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Global Events/Activator")]
    [NodeTitle("Activator:\nString Event")]
    [NodeMenuName("Activator: String Event")] 
    [NodeColor(NodeColors.grey)]
    [CreateBBVariable("ActivationName", BBVariableType.String)]
    [CreateBBVariable("ActivationStringProperty", BBVariableType.String)]
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