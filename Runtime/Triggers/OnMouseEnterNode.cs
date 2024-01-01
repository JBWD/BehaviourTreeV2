namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuFolder = "Triggers", nodeTitle = "On Mouse Enter", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnMouseEnterNode : TriggerNode
    {
        public override void OnInit()
        {
            context.behaviourTreeInstance.OnMouseEnterCollider += RunMouseEvent;
        }
        public override void OnDisable()
        {
            context.behaviourTreeInstance.OnMouseEnterCollider -= RunMouseEvent;
        }
        public void RunMouseEvent()
        {
            OnUpdate();
        }

    }
}