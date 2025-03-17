using System.Collections.Generic;
using Halcyon.BT;
using Halcyon.Combat;
using UnityEngine;
using UnityEngine.UIElements;

namespace Halcyon.BT
{


    public class NavmeshAICombatNode : ActionNode
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
         *
         *
         *
         **/
        public NodeProperty<Transform> Target { get; set; }
        [Tooltip("Distance from the target's current position to reset self.")]
        public NodeProperty<NumericProperty> ResetDistance { get; set; }
        [Tooltip("Time between last attack which will reset self.")]
        public NodeProperty<NumericProperty> ResetTime { get; set; }
        public NodeProperty<Effect> BasicAttack { get; set; }
        public NodeProperty<List<Effect>> SecondaryAttacks { get; set; }
        
        private int framesBetweenCombatEvents = 10;
        private int currentFrameCount = 0;

        private Effect currentAttack;

        /**
         *  Combat Flow
         *
         *  - Determine Attack
         *      - This is based on the list of attacks provided and Auto Attack
         *  - Move to Target In Range of Attack
         *  - Start Attacking
         *      - This will either be casting, instant or channeling.
         *  - Wait for attack to complete
         *  - Wait for delay between actions
         *  - Repeat
         * 
         */
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            if (Target.Value is null)
            {
                return Reset();
            }

            currentFrameCount++;
            if (currentFrameCount > framesBetweenCombatEvents)
            {
                context.abilityManager.TryAutoUse(Target.Value.gameObject);
                
                currentFrameCount = 0;
            }
          
            return State.Running;
        }

        private bool AttackRequirementMet()
        {
            return false;
        }

        private void DetermineAttack()
        {
   
        }


        public State Reset()
        {
            context.CurrentState = AIStates.Resetting;
            return State.Failure;
        }
      
    }
}