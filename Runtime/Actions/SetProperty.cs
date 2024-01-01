using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

namespace TheKiwiCoder {

    [BehaviourTreeNode(menuFolder = "Variable Nodes", nodeTitle = "Set Variable", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.oneTime)]
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
