using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.BT {
    [System.Serializable]
    [NodeMenuPath("Behaviour Tree/Flow")]
    [NodeIcon(NodeIcons.sequence)]
    public class Sequencer : CompositeNode {
        
        protected int current;

        protected override void OnStart() {
            current = 0;
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate()
        {
            if (children.Count == 0)
                return State.Failure;
            
            var child = children[current];
            
            switch (child.Update()) {
                case State.Running:
                    return State.Running;
                case State.Failure:
                    return State.Failure;
                case State.Success:
                    current++;  
                    break;
                
            }

            if (current >= children.Count)
            {
                current = 0;
                return State.Success;
            }

            return State.Running;
        }
    }
}