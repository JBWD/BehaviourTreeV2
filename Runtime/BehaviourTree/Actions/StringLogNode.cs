
using System;
using UnityEngine;

namespace Halcyon.BT {
    [System.Serializable]
   
    [NodeMenuPath("Behaviour Tree")]
    [NodeTitle("Debug: Log")]
    [NodeMenuName("Debug: Log")]
    [NodeIcon(NodeIcons.debug)]
    [CreateBBVariable("Message", BBVariableType.String)]
    public class StringLogNode : ActionNode {
        
        public LogType logType = LogType.Log;
        
        [Tooltip("Message to log to the console")]
        public NodeProperty<string> message = new NodeProperty<string>();

        [Tooltip("Object value appended to message.")]
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
            if (m.Trim() != "")
            {
                switch (logType)
                {
                    case LogType.Error:
                        Debug.LogError($"{m}");
                        break;
                    case LogType.Assert:
                        Debug.LogAssertion($"{m}");
                        break;
                    case LogType.Warning:
                        Debug.LogWarning($"{m}");
                        break;
                    case LogType.Log:
                        Debug.Log($"{m}");
                        break;
                    case LogType.Exception:
                        Debug.LogError($"{m}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
                
            
            return State.Success;
        }
    }
}
