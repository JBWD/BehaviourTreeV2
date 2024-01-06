using UnityEngine;

namespace TheKiwiCoder
{
    public class SetVector3Node : ActionNode
    {

        public NodeProperty<Vector3> baseValue;
        public NodeProperty<Vector3> saveValue;
        
        
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
            saveValue.Value = baseValue.Value;
            state = State.Success;
            return state;
        }
    }
}