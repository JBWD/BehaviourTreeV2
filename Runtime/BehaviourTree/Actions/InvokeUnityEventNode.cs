using UnityEngine;
using UnityEngine.Events;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "UI")]
    public class InvokeUnityEventNode : ActionNode
    {

        [NodePropertyTypeSelector(typeof(UnityEvent))]
        [Header("Note: Needs to be overriden value in instance.")]
        public NodeProperty unityEvent;
        protected override void OnStart()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnStop()
        {
            throw new System.NotImplementedException();
        }

        protected override State OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}