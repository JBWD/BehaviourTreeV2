using UnityEngine;
using UnityEngine.Serialization;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Global Events/Listener")]
    [NodeTitle("Listener:\nVector3 Event")]
    [NodeMenuName("Listener: Vector3 Event")] 
    [NodeColor(NodeColors.white)]
    [CreateBBVariable("ActivationName", BBVariableType.String)]
    [CreateBBVariable("SaveVector3Property", BBVariableType.Vector3)]
    [System.Serializable]
    public class GE_OnVector3ValueChangeListenerNode : TriggerNode
    {
        public NodeProperty<string> activationName;

        public NodeProperty<Vector3> saveVector3Value;


        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnVector3ValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnVector3ValueChange -= OnValueChange;
        }


        
        
        public void OnValueChange(string activationName, Vector3 activationValue)
        {
            if (this.activationName.Value == activationName)
            {
                saveVector3Value.Value = activationValue;
                OnUpdate();
            }

           
        }
        
        public override void UpdateDescription()
        {
            description =
                $"Listens to the Vector3 Value Change Global Event to be called with the activation name: {activationName.Value}.";
        }
    }
}