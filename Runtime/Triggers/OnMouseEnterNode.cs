namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Mouse")]
    [NodeTitle("Mouse:\nOn Mouse Enter")]
    [NodeMenuName("Mouse: On Mouse Enter")] 
    [System.Serializable]
    public class OnMouseEnterNode : TriggerNode
    {
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnMouseEnterCollider += RunMouseEvent;
        }
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnMouseEnterCollider -= RunMouseEvent;
        }
        public void RunMouseEvent()
        {
            OnUpdate();
        }

        public override void UpdateDescription()
        {
            description =
                "When the mouse starts hovering over the GameObject, all children nodes are invoked, this does not repeat like the main loop.";
        }
    }
}