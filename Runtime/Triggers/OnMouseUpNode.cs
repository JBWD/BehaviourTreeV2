namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuFolder = "Triggers", nodeTitle = "On Mouse Up", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnMouseUpNode : TriggerNode
    {
        public override void OnInit()
        {
            context.behaviourTreeInstance.OnMouseUpCollider += RunMouseEvent;
        }

        public override void OnDisable()
        {
            context.behaviourTreeInstance.OnMouseUpCollider -= RunMouseEvent;
        }
        public void RunMouseEvent()
        {
            OnUpdate();
        }
    }
}