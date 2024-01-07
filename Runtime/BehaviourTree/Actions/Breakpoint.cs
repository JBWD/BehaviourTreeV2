using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon {
    
    
    [System.Serializable]
    [BehaviourTreeNode(menuPath = "Behaviour Tree/Flow", nodeColor = NodeColors.green)]
    public class Breakpoint : ActionNode
    {
        protected override void OnStart() {
            Debug.Log("Trigging Breakpoint");
            Debug.Break();
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            return State.Success;
        }
    }
    
    
}
