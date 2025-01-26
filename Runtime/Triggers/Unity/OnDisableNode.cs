using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Unity")]
    [NodeTitle("Unity:\nOn Disable")]
    [NodeMenuName("Unity: On Disable")]
    public class OnDisableNode : TriggerNode
    {
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnDisableEvent += RunUpdate;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnDisableEvent -= RunUpdate;
        }
        public void RunUpdate()
        {
            OnUpdate();
        }
    }
}