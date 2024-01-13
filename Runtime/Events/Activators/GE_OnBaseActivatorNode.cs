namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Global Events/Activator", menuName = "Event Activator: On Base Event",
        nodeTitle = "Event Activator:\nOn Base Event", nodeColor = NodeColors.grey, nodeIcon = NodeIcons.trigger)]
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
            GlobalEvents.OnBaseEvent.Invoke(activationName.Value);
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