namespace Halcyon.BT
{
    [NodeMenuPath("Events/Listener")]
    [NodeTitle("Listener:\nBase Event")]
    [NodeMenuName("Listener: Base Event")] 
    [NodeColor(NodeColors.white)]
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