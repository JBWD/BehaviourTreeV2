namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuFolder = "Triggers", nodeTitle = "On Mouse Over", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnMouseOverNode : TriggerNode
    {
        public override void OnInit()
        {
            context.behaviourTreeInstance.OnMouseOverCollider += RunMouseEvent;
        }
        public override void OnDisable()
        {
            context.behaviourTreeInstance.OnMouseOverCollider -= RunMouseEvent;
        }
        public void RunMouseEvent()
        {
            OnUpdate();
        }
    }
}