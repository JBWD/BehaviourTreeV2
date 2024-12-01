

using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Unity")]
    [NodeTitle("Triggers:\nOn Enable")]
    [NodeMenuName("Triggers: On Enable")]
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