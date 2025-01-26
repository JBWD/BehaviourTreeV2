using System;

namespace Halcyon.BT
{


    [NodeMenuPath("Triggers/Global Events/Activator")]
    [NodeTitle("Activator:\nNumeric Event")]
    [NodeMenuName("Activator: Numeric Event")] 
    [NodeColor(NodeColors.grey)]
    [CreateBBVariable("ActivationName", BBVariableType.String)]
    [CreateBBVariable("ActivationNumericProperty", BBVariableType.Number)]
    [Serializable]
    public class GE_OnNumericValueChangeActivatorNode : ActionNode
    {

        public NodeProperty<string> activationName;
        public NodeProperty<NumericProperty> activationValue;

        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            GlobalEvents.OnNumericEvent.Invoke(activationName.Value, activationValue.Value);
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