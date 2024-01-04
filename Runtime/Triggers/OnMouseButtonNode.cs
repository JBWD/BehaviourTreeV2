namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Triggers/Mouse", nodeTitle = "On Mouse Button", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnMouseButtonNode : TriggerNode
    {
        public override void OnInit()
        {
            context.behaviourTreeInstance.OnMouseButtonCollider += RunMouseEvent;
        }

        public override void OnDisable()
        {
            context.behaviourTreeInstance.OnMouseButtonCollider -= RunMouseEvent;
        }

        public void RunMouseEvent()
        {
            OnUpdate();
        }

    }
}