using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Halcyon.BT {
    [System.Serializable]
    [BehaviourTreeNode(menuPath = "Behaviour Tree/Flow", nodeColor = NodeColors.orange, nodeIcon = NodeIcons.sequence)]
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

            return State.Running;
        }

        public override void UpdateDescription()
        {
            description = "Runs all children whether they are successful, failed, or are running.";
        }
    }
}