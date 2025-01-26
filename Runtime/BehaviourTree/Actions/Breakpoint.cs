using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.BT {
    
    
    [System.Serializable]
    [NodeMenuPath("Behaviour Tree/Flow")]
    [NodeColor(NodeColors.green)]
    public class Breakpoint : ActionNode
    {
        protected override void OnStart() {
            Debug.Break();
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            return State.Success;
        }
    }
    
    
}
