using UnityEngine;
using UnityEngine.Events;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "")]
    [System.Serializable]
    public class InvokeUnityEventNode : ActionNode
    {

        [BlackboardValueOnly]
        [Header("Note: Needs to be overriden value in instance.")]
        public NodeProperty<UnityEvent> unityEvent;

       
        public override void OnInit()
        {
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
            unityEvent.Value.Invoke();
            state = State.Success;
            return state;
        }
    }
}