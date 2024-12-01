using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Events/Activator")]
    [NodeTitle("Activator:\nVector2 Event")]
    [NodeMenuName("Activator: Vector2 Event")] 
    [NodeColor(NodeColors.grey)]
    [System.Serializable]
    public class GE_OnVector2ValueChangeActivatorNode : ActionNode
    {

        public NodeProperty<string> activationName;
        public NodeProperty<Vector2> activationValue;

        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            GlobalEvents.OnVector2ValueChange.Invoke(activationName.Value, activationValue.Value);
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