namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers/Mouse", nodeTitle = "On Mouse Button", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnMouseButtonNode : TriggerNode
    {
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnMouseButtonCollider += RunMouseEvent;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnMouseButtonCollider -= RunMouseEvent;
        }

        public void RunMouseEvent()
        {
            OnUpdate();
        }

    }
}