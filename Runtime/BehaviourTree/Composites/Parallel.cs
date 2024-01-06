using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TheKiwiCoder {
    [System.Serializable]
    [BehaviourTreeNode(menuPath = "Behaviour Tree/Flow", nodeColor = NodeColors.orange)]
    public class Parallel : CompositeNode {

        protected override void OnStart() {
            
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {

            foreach (var child in children)
            {
                child.Update();
            }

            return State.Success;
        }

        public override void UpdateDescription()
        {
            description = "Runs all children whether they are successful, failed, or are running.";
        }
    }
}