using Halcyon.BT;
using Halcyon.BT.Integrations.Combat;
using Unity.VisualScripting;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [BehaviourTreeNode(menuPath = "Combat/Functions", menuName = "Combat: Take Damage",
        nodeTitle = "Combat:\n Take Damage", nodeColor = NodeColors.blue, nodeIcon = NodeIcons.combat)]
    public class Combat_TakeDamageNode : DecoratorNode
    {
        [BlackboardValueOnly] public NodeProperty<IAttack> attack;
        [BlackboardValueOnly] public NodeProperty<float> currentHealth;
        public NodeProperty<ArmorType> armorType;
        [BlackboardValueOnly]
        public NodeProperty<float> armorAmount;
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (attack.Value != null)
            {
                currentHealth.Value -= attack.Value.GetAdjustedDamage(ArmorType.Light, 10);

                if (currentHealth.Value > 0)
                    CombatEvents.UnitDied?.Invoke(context.gameObject);
                child.Update();
                return State.Success;
            }
#if UNITY_EDITOR
            if (currentHealth.Value <= 0)
            {
                CombatEvents.UnitDied?.Invoke(context.gameObject);
                child.Update();
                return State.Success;
            }
#endif
            
            
            return State.Failure;
        }
        
        
    }
}