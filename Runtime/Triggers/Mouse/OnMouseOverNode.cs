namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Mouse")]
    [NodeTitle("Mouse:\nOn Mouse Over")]
    [NodeMenuName("Mouse: On Mouse Over")] 
    [System.Serializable]
    public class OnMouseOverNode : TriggerNode
    {
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnMouseOverCollider += RunMouseEvent;
        }
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnMouseOverCollider -= RunMouseEvent;
        }
        public void RunMouseEvent()
        {
            OnUpdate();
        }
        
        public override void UpdateDescription()
        {
            description =
                "When the mouse if hovering over the GameObject, all children nodes are invoked, this does not repeat like the main loop.";
        }
    }
}