namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Global Events/Listener")]
    [NodeTitle("Listener:\nBoolean Event")]
    [NodeMenuName("Listener: Boolean Event")] 
    [NodeColor(NodeColors.white)]
    [CreateBBVariable("ActivationName", BBVariableType.String)]
    [CreateBBVariable("saveBooleanProperty", BBVariableType.Boolean)]
    [System.Serializable]
    public class GE_OnBooleanValueChangeListenerNode : TriggerNode
    {
        public NodeProperty<string> activationName;

        public NodeProperty<bool> saveBoolValue;


        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnBoolValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnBoolValueChange -= OnValueChange;
        }


       
        
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