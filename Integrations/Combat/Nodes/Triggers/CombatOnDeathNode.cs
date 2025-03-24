using Halcyon.BT;
using UnityEngine;
using Halcyon.Combat;

namespace Halcyon.BT.Integrations.Combat
{
    [NodeMenuPath("Integrations/Combat/Triggers")]
    [NodeTitle("Combat:\nOn Death")]
    [NodeMenuName("Combat: On Death")]
    [NodeColor(NodeColors.purple)]
    [System.Serializable]
    public class CombatOnDeathNode : TriggerNode
    {
        private Health _health;

        public override void OnInit()
        {
            _health = context.health;

            if (_health != null)
            {
                _health.OnDeathAction += OnDeathAction;
            }
        }

        public override void OnDisable()
        {
            if (_health != null)
            {
                _health.OnDeathAction -= OnDeathAction;
            }
        }

        private void OnDeathAction()
        {
            if (child != null)
            {
                child.Update();
            }
        }
    }
}
