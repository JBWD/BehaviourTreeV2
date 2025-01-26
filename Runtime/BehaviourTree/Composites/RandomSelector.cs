using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Halcyon.BT {
    [System.Serializable]
    [NodeMenuPath("Behaviour Tree/Flow")]
    [NodeIcon(NodeIcons.random)]
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