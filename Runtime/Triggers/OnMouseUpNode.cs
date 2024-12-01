namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Mouse")]
    [NodeTitle("Mouse:\nOn Mouse Up")]
    [NodeMenuName("Mouse: On Mouse Up")] 
    [System.Serializable]
    public class OnMouseUpNode : TriggerNode
    {
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnMouseUpCollider += RunMouseEvent;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnMouseUpCollider -= RunMouseEvent;
        }
        public void RunMouseEvent()
        {
            OnUpdate();
        }
        
        public override void UpdateDescription()
        {
            description =
                "When the GameObject is click up on, all children nodes are invoked, this does not repeat like the main loop.";
        }
    }
}