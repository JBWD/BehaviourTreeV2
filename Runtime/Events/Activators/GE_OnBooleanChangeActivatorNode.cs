using System;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Global Events/Activator", menuName = "Event Activator: On Boolean Change",
        nodeTitle = "Event Activator:\nOn Boolean Change", nodeColor = NodeColors.grey, nodeIcon = NodeIcons.trigger)]
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