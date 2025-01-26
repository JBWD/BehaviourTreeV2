namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Global Events/Activator")]
    [NodeTitle("Activator:\nBase Event")]
    [NodeMenuName("Activator: Base Event")] 
    [NodeColor(NodeColors.grey)]
    [CreateBBVariable("ActivationName", BBVariableType.String)]
    [System.Serializable]
    public class GE_OnBaseActivatorNode : ActionNode
    {

        public NodeProperty<string> activationName;

        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            GlobalEvents.OnBaseEvent?.Invoke(activationName.Value);
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            description =
                $"Activates a value change event for {activationName.Value}.";
        }
    }
}