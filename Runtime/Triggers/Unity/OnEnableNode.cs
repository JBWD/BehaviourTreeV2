

using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Unity")]
    [NodeTitle("Unity:\nOn Enable")]
    [NodeMenuName("Unity: On Enable")]
    public class OnEnableNode : TriggerNode
    {
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnEnableEvent += RunUpdate;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnEnableEvent -= RunUpdate;
        }

        public void RunUpdate()
        {
            OnUpdate();
        }
    }
}