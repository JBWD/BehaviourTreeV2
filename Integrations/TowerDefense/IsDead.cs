using Halcyon;
using Unity.VisualScripting;
using UnityEngine;

namespace Addons.TowerDefense
{
    public class IsDead : DecoratorNode
    {
        [BlackboardValueOnly] public NodeProperty<int> currentHealth;
        public NodeProperty<bool> desiredCondition;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if ((currentHealth.Value <= 0) == desiredCondition.Value)
            {
                child.Update();
                return state = State.Success;
            }

            return state = State.Failure;
        }


        public override void UpdateDescription()
        {
            if (desiredCondition.Value)
            {
                description = $"(Dead) Runs the child if the current health is less than or equal to 0";
            }
            else
            {
                description = $"(Alive) Runs the child if the current health is greater than 0";
            }
            
        }
    }
}