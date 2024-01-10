namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Mouse", nodeTitle = "On Mouse Up", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
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
    }
}