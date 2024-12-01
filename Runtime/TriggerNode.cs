using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers")]
    [NodeIcon(NodeIcons.trigger)]
    [NodeColor(NodeColors.purple)]
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