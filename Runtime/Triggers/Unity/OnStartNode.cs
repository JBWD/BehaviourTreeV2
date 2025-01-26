namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Unity")]
    [NodeTitle("Unity:\nOn Start")]
    [NodeMenuName("Unity: On Start")] 
    [NodeColor(NodeColors.red)]
    public class OnStartNode : TriggerNode
    {
        public override void OnInit()
        {
            child?.Update();
        }
    }
}