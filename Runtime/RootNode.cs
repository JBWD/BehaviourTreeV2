using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TheKiwiCoder {

    [BehaviourTreeNode(nodeColor = NodeColors.red, nodeTitle = "Root Node")]
    [System.Serializable]
    public class RootNode : Node {

        [SerializeReference]
        [HideInInspector] 
        public Node child;

        protected override void OnStart()
        {
            description = "Node the game loop starts in.";
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