using System;

namespace Halcyon.BT
{


    [NodeMenuPath("Events/Activator")]
    [NodeTitle("Activator:\nFloat Event")]
    [NodeMenuName("Activator: Float Event")] 
    [NodeColor(NodeColors.grey)]
    [Serializable]
    public class GE_OnFloatValueChangeActivatorNode : ActionNode
    {

        public NodeProperty<string> activationName;
        public NodeProperty<float> activationValue;

        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            GlobalEvents.OnFloatValueChange.Invoke(activationName.Value, activationValue.Value);
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