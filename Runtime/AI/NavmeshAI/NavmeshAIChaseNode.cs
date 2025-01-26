namespace Halcyon.BT
{
    public class NavmeshAIChaseNode : ActionNode
    { 
        
        
       /**
        * All AI nodes will require the BehaviourTreeAI script to be added in the context menu.
        * This will get initialized in a context integration and through the init calls.
        *
        * Variables:
        * target
        * Health
        * Detection Location (Point to move back to if lost target)
        * Attack Distance
        * reset distance
        * Current State
        * MoveSpeed
        * TurnSpeed
        *
        * Animations are not done through this and should be done as a separate node.
        * 
        * How it works
        * 1 - Saves the detection point
        * 2 - moves towards the target
        * 3 - Once within the attack distance of the target will change attack state.
        * 4 - Target is lost or reset distance is reached
        * 5 - Sets health to invulnerable and healing over time starts
        * 6 - moves to the detection location
        * 7 - Repeats steps 2-6
        *
        * Since Attacks are their own state this will change to that state, However the detection point will stay the same unless the mob resets.
        * Changes state internally
       */

        
        
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            return State.Running;
        }
    }
}