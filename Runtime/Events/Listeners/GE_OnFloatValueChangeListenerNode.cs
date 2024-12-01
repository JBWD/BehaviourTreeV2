
namespace Halcyon.BT
{

    [NodeMenuPath("Events/Listener")]
    [NodeTitle("Listener:\nFloat Event")]
    [NodeMenuName("Listener: Float Event")] 
    [NodeColor(NodeColors.white)]
    [System.Serializable]
    public class GE_OnFloatValueChangeListenerNode : TriggerNode
    {
        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnFloatValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnFloatValueChange -= OnValueChange;
        }


        public NodeProperty<string> activationName;

        public NodeProperty<float> saveFloatValue;
        
        
        
        public void OnValueChange(string activationName, float activationValue)
        {
            if (this.activationName.Value == activationName)
            {
                saveFloatValue.Value = activationValue;
                OnUpdate();
            }

           
        }
        public override void UpdateDescription()
        {
            description =
                $"Listens to the Float Value Change Global Event to be called with the activation name: {activationName.Value}.";
        }
    }
}