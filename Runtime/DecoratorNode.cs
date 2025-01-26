using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.BT {
    
    [NodeColor(NodeColors.blue)]
    public abstract class DecoratorNode : Node {

        [SerializeReference]
        [HideInInspector] 
        public Node child;
        
    }
}
