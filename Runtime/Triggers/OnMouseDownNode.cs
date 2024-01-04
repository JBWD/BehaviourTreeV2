namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Triggers/Mouse", nodeTitle = "On Mouse Down", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnMouseDownNode : TriggerNode
    {
        public override void OnInit()
        {
            context.behaviourTreeInstance.OnMouseDownCollider += RunMouseEvent;
        }

        public override void OnDisable()
        {
            context.behaviourTreeInstance.OnMouseDownCollider -= RunMouseEvent;
        }
        public void RunMouseEvent()
        {
            OnUpdate();
        }

    }
}