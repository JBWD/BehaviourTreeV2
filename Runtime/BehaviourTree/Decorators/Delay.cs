using Halcyon.BT;
using UnityEngine;

namespace Halcyon.BT
{
    [System.Serializable]
    [NodeMenuPath("Behaviour Tree/Flow")]
    [NodeIcon(NodeIcons.time)]
    [CreateBBVariable("Duration", BBVariableType.Number)]
    public class Delay : CompositeNode
    {
        [Tooltip("Amount of time to wait before returning success")]
        public NodeProperty<NumericProperty> duration;

        private float timeRemaining;
        protected override void OnStart()
        {
            timeRemaining = duration.Value.FloatValue;
        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {

            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                foreach (var child in children)
                    child.Update();
                return State.Success;
            }

            return State.Running;
        }
    }
}