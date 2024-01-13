using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Global Events/Listener", menuName = "Event Listener: On Vector2 Change",
        nodeTitle  = "Event Listener:\nOn Vector2 Change", nodeColor = NodeColors.white, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public class GE_OnVector2ValueChangeListenerNode : TriggerNode
    {
        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnVector2ValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnVector2ValueChange -= OnValueChange;
        }


        public NodeProperty<string> activationName;

        public NodeProperty<Vector2> saveFloatValue;
        
        
        
        public void OnValueChange(string activationName, Vector2 activationValue)
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
                $"Listens to the Vector2 Value Change Global Event to be called with the activation name: {activationName.Value}.";
        }
    }
}