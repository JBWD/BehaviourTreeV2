using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.BT {

    [System.Serializable]
    [NodeMenuPath("Behaviour Tree/Flow")]
    [NodeIcon(NodeIcons.time)]
    [CreateBBVariable("Duration",BBVariableType.Number)]
    public class Wait : ActionNode
    {

        [Tooltip("Amount of time to wait before returning success")]
        public NodeProperty<NumericProperty> duration;
        private float timeRemaining;
        protected override void OnStart()
        {
            timeRemaining = duration.Value.FloatValue;
        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                return State.Success;
            }
            return State.Running;
        }
    }
}
