namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Global Events/Listener", menuName = "Event Listener: On Integer Change",nodeTitle  = "Event Listener:\nOn Integer Change", 
        nodeColor = NodeColors.white, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public class GE_OnIntegerValueChangeListenerNode : TriggerNode
    {
        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnIntegerValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnIntegerValueChange -= OnValueChange;
        }


        public NodeProperty<string> activationName;

        public NodeProperty<int> saveIntegerValue;
        
        
        
        public void OnValueChange(string activationName, int activationValue)
        {
            
            if (this.activationName.Value == activationName && saveIntegerValue.Value  == activationValue)
            {
                
                OnUpdate();
            }

           
        }
        public override void UpdateDescription()
        {
            description =
                $"Listens to the Integer Value Change Global Event to be called with the activation name: {activationName.Value}.";
        }
    }
}