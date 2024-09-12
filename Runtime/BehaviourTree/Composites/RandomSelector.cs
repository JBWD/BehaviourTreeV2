using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Halcyon.BT {
    [System.Serializable]
    [BehaviourTreeNode(menuPath = "Behaviour Tree/Flow", nodeColor = NodeColors.orange, nodeIcon = NodeIcons.random)]
    public class RandomSelector : CompositeNode {
        protected int current;

        protected override void OnStart() {
            current = Random.Range(0, children.Count);
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            var child = children[current];
            return child.Update();
        }
    }
}