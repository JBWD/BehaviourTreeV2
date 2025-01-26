using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Halcyon.BT;

namespace Halcyon.BT {

    [BehaviourTreeNode(menuPath = "Behaviour Tree", nodeTitle = "Set Property", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.oneTime)]
    [NodeMenuPath("Behaviour Tree")]
    [NodeMenuName("Set Property")]
    [NodeTitle("Set Property")]
    [NodeIcon(NodeIcons.save)]
    [System.Serializable]
    public class SetProperty : ActionNode
    {
        public BlackboardKeyValuePair pair;

        protected override void OnStart() {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            
            pair.WriteValue();
            return State.Success;
        }
    }
}
