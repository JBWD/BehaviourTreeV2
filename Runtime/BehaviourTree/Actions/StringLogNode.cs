using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

namespace Halcyon {
    [System.Serializable]
    [BehaviourTreeNode(menuPath = "Behaviour Tree/Debug", nodeTitle = "Debug: Log", nodeColor = NodeColors.green, nodeIcon = NodeIcons.debug)]
    public class StringLogNode : ActionNode {
        
        [Tooltip("Message to log to the console")]
        public NodeProperty<string> message = new NodeProperty<string>();

        protected override void OnStart() {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            Debug.Log($"{message.Value}");
            return State.Success;
        }
    }
}
