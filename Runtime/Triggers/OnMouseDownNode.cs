namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Mouse", nodeTitle = "On Mouse Down", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public class OnMouseDownNode : TriggerNode
    {
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnMouseDownCollider += RunMouseEvent;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnMouseDownCollider -= RunMouseEvent;
        }
        public void RunMouseEvent()
        {
            OnUpdate();
        }

        public override void UpdateDescription()
        {
            description =
                "When the GameObject is click down on, all children nodes are invoked, this does not repeat like the main loop.";
        }
    }
}