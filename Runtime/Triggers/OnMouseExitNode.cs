

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers/Mouse", nodeTitle = "On Mouse Exit", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
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
            description = "Fires when the mouse stops hovering the GameObject.";
        }
    }
}