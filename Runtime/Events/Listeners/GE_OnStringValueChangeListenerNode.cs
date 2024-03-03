namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Global Events/Listener", menuName = "Event Listener: On String Change",nodeTitle  = "Event Listener:\nOn String Change", 
        nodeColor = NodeColors.white, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public class GE_OnStringValueChangeListenerNode : TriggerNode
    {
        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnStringValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnStringValueChange -= OnValueChange;
        }


        public NodeProperty<string> activationName;

        public NodeProperty<string> saveFloatValue;
        
        
        
        public void OnValueChange(string activationName, string activationValue)
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
                $"Listens to the String Value Change Global Event to be called with the activation name: {activationName.Value}.";
        }
    }
}