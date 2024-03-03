using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon {

    [System.Serializable]
    [BehaviourTreeNode(menuPath = "Behaviour Tree/Flow", nodeColor = NodeColors.green,nodeIcon = NodeIcons.time)]
    public class Wait : ActionNode {

        [Tooltip("Amount of time to wait before returning success")] public float duration = 1;
        float startTime;
        public bool restartAfterComplete = false;
        
        protected override void OnStart() {
            startTime = Time.time;
        }

        protected override void OnStop() {
            
        }

        protected override State OnUpdate() {
            
            
            
            float timeRemaining = Time.time - startTime;
            if (timeRemaining > duration)
            {
                return State.Success;
            }
            return State.Running;
        }
    }
}
