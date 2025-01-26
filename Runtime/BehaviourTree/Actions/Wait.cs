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
        float startTime;

        protected override void OnStart() {
            startTime = Time.time;
        }

        protected override void OnStop() {
            
        }

        protected override State OnUpdate() {
            
            float timeRemaining = Time.time - startTime;
            if (timeRemaining > duration.Value.FloatValue)
            {
                return State.Success;
            }
            return State.Running;
        }
    }
}
