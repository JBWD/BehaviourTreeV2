using UnityEngine;

namespace Halcyon.BT.Integrations.Combat
{
    [BehaviourTreeNode(menuPath = "Combat/Event", menuName = "Combat: Unit Died",
        nodeTitle = "Combat:\n Unit Died", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class Combat_DiedNode : TriggerNode
    {
        public override void OnInit()
        {
            CombatEvents.UnitDied += UnitDied;
        }

        public void UnitDied(GameObject gameObject)
        {
            if (gameObject != context.gameObject)
                return;

            child.Update();
        }

    }
}