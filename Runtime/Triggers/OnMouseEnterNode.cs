namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Mouse", nodeTitle = "On Mouse Enter", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
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

    }
}