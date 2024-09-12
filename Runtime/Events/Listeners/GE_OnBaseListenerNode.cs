namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Global Events/Listener",
        menuName = "Event Listener: On Base Event", nodeTitle = "Event Listener:\nOn Base Event",
        nodeColor = NodeColors.white, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public class GE_OnBaseListenerNode : TriggerNode
    {
        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnBaseEvent += OnBaseEvent;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnBaseEvent -= OnBaseEvent;
        }


        public NodeProperty<string> activationName;




        public void OnBaseEvent(string activationName)
        {
            if (this.activationName.Value == activationName)
            {
                OnUpdate();
            }


        }

        public override void UpdateDescription()
        {
            description =
                $"Listens to the Base Global Event to be called with the activation name: {activationName.Value}.";
        }
    }
}