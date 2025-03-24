using Halcyon.BT;
using UnityEngine;
using Halcyon.Combat;
using UnityEngine.Serialization;

namespace Halcyon.BT.Integrations.Combat
{
    
    [NodeMenuPath("Integrations/Combat/Triggers")]
    [NodeTitle("Combat:\nOn Heal")]
    [NodeMenuName("Combat: On Heal")] 
    [NodeColor(NodeColors.purple)]
    [CreateBBVariable("DamageHealed", BBVariableType.Number)]
    [System.Serializable]
    public class CombatOnHealNode : TriggerNode
    {
        private Health _health;

        public NodeProperty<NumericProperty> DamageHealed = new NodeProperty<NumericProperty>();
            
        public override void OnInit()
        {
            _health = context.health;

            if (_health != null)
            {
                _health.OnHealDamageAction += OnHealDamageAction;
            }
        }
            
        public override void OnDisable()
        {
            if (_health != null)
            {
                _health.OnHealDamageAction -= OnHealDamageAction;
            }
        }

        private void OnHealDamageAction(float value)
        {
            DamageHealed.Value.FloatValue = value;
            if (child != null)
            {
                child.Update();
            }
        }
    }
}
