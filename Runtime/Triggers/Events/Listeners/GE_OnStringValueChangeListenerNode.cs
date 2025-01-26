using UnityEngine.Serialization;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Global Events/Listener")]
    [NodeTitle("Listener:\nString Event")]
    [NodeMenuName("Listener: String Event")] 
    [NodeColor(NodeColors.white)]
    [CreateBBVariable("ActivationName", BBVariableType.String)]
    [CreateBBVariable("SaveStringProperty", BBVariableType.String)]
    [System.Serializable]
    public class GE_OnStringValueChangeListenerNode : TriggerNode
    {
        public NodeProperty<string> activationName;

        public NodeProperty<string> saveStringValue;
        
        
        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnStringValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnStringValueChange -= OnValueChange;
        }


        
        public void OnValueChange(string activationName, string activationValue)
        {
            if (this.activationName.Value == activationName)
            {
                saveStringValue.Value = activationValue;
                OnUpdate();
            }

           
        }
        public override void UpdateDescription()
        {
            description =
                $"Listens to the String Value Change Global Event to be called with the activation name: {activationName.Value}.";
        }
    }
}