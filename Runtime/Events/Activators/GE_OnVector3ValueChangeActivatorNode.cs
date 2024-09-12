using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Global Events/Activator", menuName = "Event Activator: On Vector3 Change",
        nodeTitle = "Event Activator:\nOn Vector3 Change", nodeColor = NodeColors.grey, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public class GE_OnVector3ValueChangeActivatorNode : ActionNode
    {

        public NodeProperty<string> activationName;
        public NodeProperty<Vector3> activationValue;

        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            GlobalEvents.OnVector3ValueChange.Invoke(activationName.Value, activationValue.Value);
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