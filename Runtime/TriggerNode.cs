using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuFolder = "Triggers", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public abstract class TriggerNode : DecoratorNode
    {
        
        
        protected override void OnStart() {

        }

        protected override void OnStop() {

        }

        protected override State OnUpdate() {
            if (child != null)
            {
                state = child.Update();
                
            } else
            {
                state = State.Failure;
            }
            return state;
        }

        
        
    }
}