namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Triggers & Events", menuName = "On Start Node",
        nodeTitle = "Start Node", nodeColor = NodeColors.red, nodeIcon = NodeIcons.trigger)]
    public class OnStartNode : TriggerNode
    {
        public override void OnInit()
        {
            child?.Update();
        }
    }
}