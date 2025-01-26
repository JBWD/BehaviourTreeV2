using UnityEngine;
using UnityEngine.Serialization;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Global Events/Listener")]
    [NodeTitle("Listener:\nVector2 Event")]
    [NodeMenuName("Listener: Vector2 Event")] 
    [NodeColor(NodeColors.white)]
    [CreateBBVariable("ActivationName", BBVariableType.String)]
    [CreateBBVariable("SaveVector2Property", BBVariableType.Vector2)]
    [System.Serializable]
    public class GE_OnVector2ValueChangeListenerNode : TriggerNode
    {
        
        public NodeProperty<string> activationName;

        public NodeProperty<Vector2> saveVector2Value;



        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnVector2ValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnVector2ValueChange -= OnValueChange;
        }


        public void OnValueChange(string activationName, Vector2 activationValue)
        {
            if (this.activationName.Value == activationName)
            {
                saveVector2Value.Value = activationValue;
                OnUpdate();
            }

           
        }
        public override void UpdateDescription()
        {
            description =
                $"Listens to the Vector2 Value Change Global Event to be called with the activation name: {activationName.Value}.";
        }
    }
}