using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {
    [BehaviourTreeNode(menuFolder = "Decorator Nodes", nodeColor = NodeColors.blue)]
    public abstract class DecoratorNode : Node {

        [SerializeReference]
        [HideInInspector] 
        public Node child;
        
    }
}
