namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Mouse", nodeTitle = "On Mouse Button", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
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

        
        public override void UpdateDescription()
        {
            description =
                "When the GameObject is click down and up, all children nodes are invoked, this does not repeat like the main loop.";
        }
        
    }
}