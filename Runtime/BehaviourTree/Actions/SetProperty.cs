using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Halcyon;

namespace Halcyon {

    [BehaviourTreeNode(menuPath = "Behaviour Tree", nodeTitle = "Set Property", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.oneTime)]
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
