using System;

namespace Halcyon.BT
{
    [NodeMenuPath("Events/Activator")]
    [NodeTitle("Activator:\nBoolean Event")]
    [NodeMenuName("Activator: Boolean Event")] 
    [NodeColor(NodeColors.grey)]
    [Serializable]
    public class GE_OnBooleanChangeActivatorNode : ActionNode
    {
        public NodeProperty<string> activationName;
        public NodeProperty<bool> activationValue;

        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            GlobalEvents.OnBoolValueChange.Invoke(activationName.Value, activationValue.Value);
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