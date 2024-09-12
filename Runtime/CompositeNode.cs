using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Color = System.Drawing.Color;

namespace Halcyon.BT {

    [BehaviourTreeNode(menuPath = "Flow Nodes", nodeColor = NodeColors.orange)]
    [System.Serializable]
    public abstract class CompositeNode : Node {

        [HideInInspector] 
        [SerializeReference]
        public List<Node> children = new List<Node>();
    }
}