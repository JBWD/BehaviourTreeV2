using Halcyon.BT;
using Halcyon.Combat;
using UnityEngine;

namespace Halcyon.BT.Integrations.Combat
{
    [NodeMenuPath("Integrations/Combat/Triggers")]
    [NodeTitle("Combat:\nOn Take Damage")]
    [NodeMenuName("Combat: On Take Damage")] 
    [NodeColor(NodeColors.purple)]
    [CreateBBVariable("DamageTaken", BBVariableType.Number)]
    [System.Serializable]
    public class CombatOnTakeDamageNode : TriggerNode
    {
        private Health _health;
        
        public NodeProperty<NumericProperty> DamageTaken = new NodeProperty<NumericProperty>();
        
        public override void OnInit()
        {
            _health = context.health;

            if (_health != null)
            {
                _health.OnTakeDamageAction += OnTakeDamageAction;
            }
        }
        
        public override void OnDisable()
        {
            if (_health != null)
            {
                _health.OnTakeDamageAction -= OnTakeDamageAction;
            }
        }

        private void OnTakeDamageAction(float value)
        {
            DamageTaken.Value.FloatValue = value;
            if (child != null)
            {
                child.Update();
            }
        }
    }
}