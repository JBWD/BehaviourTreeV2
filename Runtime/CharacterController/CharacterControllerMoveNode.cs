using UnityEngine;

namespace Halcyon.BT
{
    public class CharacterControllerMoveNode : ActionNode
    {
        //MovementInput
        //MoveSpeed
        
        [BlackboardValueOnly]
        public NodeProperty<Vector3> movementInput;

        public NodeProperty<NumericProperty> moveSpeed;
        [BlackboardValueOnly]
        public NodeProperty<Vector3> velocity;

        
        

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
            velocity.Value = new Vector3(movementInput.Value.x * moveSpeed.Value.FloatValue * Time.deltaTime, 
                velocity.Value.y, 
                movementInput.Value.z * moveSpeed.Value.FloatValue * Time.deltaTime).normalized;
            
            
            if (context.characterController != null)
            {
                
                context.characterController.Move(velocity.Value * Time.deltaTime);
                return State.Success;
            }
            else
            {
                return State.Failure;
            }
        }
    }
}