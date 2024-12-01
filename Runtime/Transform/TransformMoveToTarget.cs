using Halcyon.BT;
using UnityEngine;


namespace Halcyon.BT
{
    [NodeMenuName("Transform: Move to Target"), NodeMenuPath("Transform")]
    [NodeTitle("Transform:\nMove To Target")]

    public class TransformMoveToTarget : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<Transform> Target;
        public NodeProperty<NumericProperty> MoveSpeed;
        public NodeProperty<NumericProperty> StoppingDistance;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (Target.Value == null)
                return State.Failure;
            
            if(Vector3.Distance(Target.Value.position, context.transform.position) > StoppingDistance.Value.FloatValue) 
                context.transform.position = Vector3.MoveTowards(context.transform.position, Target.Value.position, MoveSpeed.Value.FloatValue * Time.deltaTime);
            
            return State.Success;
        }
    }
}