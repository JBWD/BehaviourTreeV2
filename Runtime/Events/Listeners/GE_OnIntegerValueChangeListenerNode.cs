namespace Halcyon.BT
{
   
    [NodeMenuPath("Events/Listener")]
    [NodeTitle("Listener:\nInteger Event")]
    [NodeMenuName("Listener: Integer Event")] 
    [NodeColor(NodeColors.white)]
    [System.Serializable]
    public class GE_OnIntegerValueChangeListenerNode : TriggerNode
    {
        public override void OnInit()
        {
            base.OnInit();
            GlobalEvents.OnIntegerValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnIntegerValueChange -= OnValueChange;
        }

        public NodeProperty<string> activationName;

        public NodeProperty<int> saveIntegerValue;

        public void OnValueChange(string activationN, int activationValue)
        {
            
            if (this.activationName.Value == activationN){
                if(saveIntegerValue != null)
                    saveIntegerValue.Value = activationValue;
                OnUpdate();
            }

           
        }
        public override void UpdateDescription()
        {
            description =
                $"Listens to the Integer Value Change Global Event to be called with the activation name: {activationName.Value}.";
        }
    }
}