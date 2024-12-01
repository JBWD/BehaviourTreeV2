

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Mouse")]
    [NodeTitle("Mouse:\nOn Mouse Exit")]
    [NodeMenuName("Mouse: On Mouse Exit")] 
    [System.Serializable]
    public class OnMouseExitNode : TriggerNode
    {
        
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnMouseExitCollider += RunMouseEvent;
        }
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnMouseExitCollider -= RunMouseEvent;
        }
        public void RunMouseEvent()
        {
            OnUpdate();
        }

        public override void UpdateDescription()
        {
            description =
                "When the mouse exits hovering over the GameObject, all children nodes are invoked, this does not repeat like the main loop.";
        }
    }
}