namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Global Events/Listener")]
    [NodeTitle("Listener:\nBase Event")]
    [NodeMenuName("Listener: Base Event")] 
    [NodeColor(NodeColors.white)]
    [CreateBBVariable("ActivationName", BBVariableType.String)]
    [System.Serializable]
    public class GE_OnBaseListenerNode : TriggerNode
    {
        
        public NodeProperty<string> activationName;


        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnBaseEvent += OnBaseEvent;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnBaseEvent -= OnBaseEvent;
        }




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