using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Halcyon {

    [BehaviourTreeNode(menuPath = "Action Nodes", nodeColor = NodeColors.green, nodeIcon = NodeIcons.none)]
    [System.Serializable]
    public abstract class ActionNode : Node {

    }
}