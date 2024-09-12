
using UnityEngine;

namespace Halcyon.BT {
    [System.Serializable]
    [BehaviourTreeNode(menuPath = "Behaviour Tree/Debug", nodeTitle = "Debug: Log", nodeColor = NodeColors.green, nodeIcon = NodeIcons.debug)]
    public class StringLogNode : ActionNode {
        
        [Tooltip("Message to log to the console")]
        public NodeProperty<string> message = new NodeProperty<string>();

        public NodeProperty<object> objectValue;
        
        protected override void OnStart() {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate()
        {
            var objMessage = "null";
            try {
                objMessage = blackboard.GetValueString(objectValue);
            }
            catch { // ignored
            }

            string m = message.Value +" "+ objMessage;;
            if(m.Trim() != "")
                Debug.Log($"{m}");
            
            return State.Success;
        }
    }
}
