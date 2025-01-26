using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.BT {
    
    [NodeMenuPath("Behaviour Tree/Flow")]
    [NodeIcon(NodeIcons.repeat)]
    [System.Serializable]
    public class Repeat : DecoratorNode {
        [Tooltip("Restarts the subtree on success")] public bool restartOnSuccess = true;
        [Tooltip("Restarts the subtree on failure")] public bool restartOnFailure = true;
        [Tooltip("Maximum number of times the subtree will be repeated. Set to 0 to loop forever")] public int maxRepeats = 0;

        int iterationCount = 0;

        protected override void OnStart() {
            iterationCount = 0;
        }

        protected override void OnStop() {

        }

        protected override State OnUpdate() {
            if (child == null) {
                return State.Failure;
            }

            switch (child.Update()) {
                case State.Running:
                    break;
                case State.Failure:
                    if (restartOnFailure) {
                        iterationCount++;
                        if (iterationCount >= maxRepeats && maxRepeats > 0) {
                            return State.Failure;
                        } else {
                            return State.Running;
                        }
                    } else {
                        return State.Failure;
                    }
                case State.Success:
                    if (restartOnSuccess) {
                        iterationCount++;
                        if (iterationCount >= maxRepeats && maxRepeats > 0) {
                            return State.Success;
                        } else {
                            return State.Running;
                        }
                    } else {
                        return State.Success;
                    }
            }
            return State.Running;
        }

        public override void UpdateDescription()
        {
            
            
            
            description = "Repeats all children";
            
            if (maxRepeats == 0)
                description += " indefinitely.\n";
            else
                description += $" {maxRepeats} time(s).\n";
            
            if (restartOnSuccess)
                description += " if children are successful,";
            if(restartOnFailure)
                description += " if children failed,";
            
        }
    }


}
