using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.BT {
    [System.Serializable]
    
    [NodeMenuPath("Behaviour Tree/Flow")]
    public class Failure : DecoratorNode {
        protected override void OnStart() {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            if (child == null) {
                return State.Failure;
            }

            var state = child.Update();
            if (state == State.Success) {
                return State.Failure;
            }
            return state;
        }
    }
}