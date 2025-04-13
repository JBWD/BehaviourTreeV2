using System;
using Halcyon.BT;
using UnityEngine;

namespace Halcyon.BT
{

    [NodeMenuPath("Triggers/Unity")]
    [NodeTitle("Unity:\nOn Destroy")]
    [NodeMenuName("Unity: On Destroy")]
    public class OnDestroyNode : TriggerNode
    {
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnDestroyEvent += RunUpdate;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnDestroyEvent -= RunUpdate;
        }

        public void RunUpdate()
        {
            OnUpdate();
        }
    }
}