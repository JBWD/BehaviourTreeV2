using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Trigger Nodes", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public abstract class TriggerNode : RootNode
    {
        
        protected override void OnStart() {

        }

        protected override void OnStop() {

        }

        protected override State OnUpdate() {
            if (child != null) {
                return child.Update();
            } else {
                return State.Failure;
            }
        }

        
        
    }
}