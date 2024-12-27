using UnityEngine;

namespace Halcyon.BT
{
    
    public class CharacterControllerCanJumpNode : DecoratorNode
    {

        [BlackboardValueOnly]
        public NodeProperty<bool> IsGrounded;

        public NodeProperty<NumericProperty> NumberOfAllowedJumps;
        public NodeProperty<NumericProperty> CurrentNumberOfJumps;

        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {

            return State.Success;
        }

        public override void UpdateDescription()
        {
            description =
                "Checks to see if the player can jump, This includes if the player is grounded, has a certain number of jumps left," +
                "or can jump in the air. Follow this node with a Character Controller: Jump Node to apply the jump.";
        }
    }
}