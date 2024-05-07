using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon {

    [System.Serializable]
    [BehaviourTreeNode(menuPath = "Behaviour Tree/Flow", nodeColor = NodeColors.green,nodeIcon = NodeIcons.time)]
    public class Wait : ActionNode
    {

        [Tooltip("Amount of time to wait before returning success")]
        public NodeProperty<float> duration;
        float startTime;

        protected override void OnStart() {
            startTime = Time.time;
        }

        protected override void OnStop() {
            
        }

        protected override State OnUpdate() {
            
            float timeRemaining = Time.time - startTime;
            if (timeRemaining > duration.Value)
            {
                return State.Success;
            }
            return State.Running;
        }
    }
}
