using Halcyon.BT;
using UnityEngine;

namespace Halcyon.BT
{
    [System.Serializable]
    [BehaviourTreeNode(menuPath = "Behaviour Tree/Flow", nodeColor = NodeColors.orange ,nodeIcon = NodeIcons.time)]
    public class Delay : CompositeNode
    {
        [Tooltip("Amount of time to wait before returning success")]
        public NodeProperty<float> duration;

        float startTime;

        protected override void OnStart()
        {
            startTime = Time.time;
        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {

            float timeRemaining = Time.time - startTime;
            if (timeRemaining > duration.Value)
            {
                foreach (var child in children)
                    child.Update();
                return State.Success;
            }

            return State.Running;
        }
    }
}