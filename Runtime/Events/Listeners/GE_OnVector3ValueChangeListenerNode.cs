using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Global Events/Listener", menuName = "Event Listener: On Vector3 Change",
        nodeTitle  = "Event Listener:\nOn Vector3 Change", nodeColor = NodeColors.white, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public class GE_OnVector3ValueChangeListenerNode : TriggerNode
    {
        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnVector3ValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnVector3ValueChange -= OnValueChange;
        }


        public NodeProperty<string> activationName;

        public NodeProperty<Vector3> saveFloatValue;
        
        
        
        public void OnValueChange(string activationName, Vector3 activationValue)
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
                $"Listens to the Vector3 Value Change Global Event to be called with the activation name: {activationName.Value}.";
        }
    }
}