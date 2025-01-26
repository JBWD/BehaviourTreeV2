
using Unity.VisualScripting;

namespace Halcyon.BT
{

    [NodeMenuPath("Triggers/Global Events/Listener")]
    [NodeTitle("Listener:\nNumeric Event")]
    [NodeMenuName("Listener: Numeric Event")] 
    [NodeColor(NodeColors.white)]
    [CreateBBVariable("ActivationName", BBVariableType.String)]
    [CreateBBVariable("SaveNumericProperty", BBVariableType.Number)]
    [System.Serializable]
    public class GE_OnNumericValueChangeListenerNode : TriggerNode
    {
        
        public NodeProperty<string> activationName;

        public NodeProperty<NumericProperty> saveNumericProperty;


        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnNumericEvent += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnNumericEvent -= OnValueChange;
        }


        
        public void OnValueChange(string activationName, NumericProperty activationValue)
        {
            if (this.activationName.Value == activationName)
            {
                saveNumericProperty.Value.DoubleValue = activationValue.DoubleValue;
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