using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {

    [BehaviourTreeNode(nodeColor = NodeColors.red, nodeTitle = "Root Node")]
    [System.Serializable]
    public class RootNode : Node {

        [SerializeReference]
        [HideInInspector] 
        public Node child;

        protected override void OnStart() {

        }

        protected override void OnStop() {

        }

        protected override State OnUpdate() {
            if (child != null) {
                return child.Update();
            } else {
                return State.Failure;
            }
        }
    }
}