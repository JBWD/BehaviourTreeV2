namespace Halcyon.BT
{
    [NodeMenuPath("Events/Listener")]
    [NodeTitle("Listener:\nBoolean Event")]
    [NodeMenuName("Listener: Boolean Event")] 
    [NodeColor(NodeColors.white)]
    [System.Serializable]
    public class GE_OnBooleanValueChangeListenerNode : TriggerNode
    {
        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnBoolValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnBoolValueChange -= OnValueChange;
        }


        public NodeProperty<string> activationName;

        public NodeProperty<bool> saveBoolValue;
        
        
        
        public void OnValueChange(string activationName, bool activationValue)
        {
            if (this.activationName.Value == activationName)
            {
                saveBoolValue.Value = activationValue;
                OnUpdate();
            }

           
        }
        public override void UpdateDescription()
        {
            description =
                $"Listens to the Boolean Value Change Global Event to be called with the activation name: {activationName.Value}.";
        }
    
    }
}