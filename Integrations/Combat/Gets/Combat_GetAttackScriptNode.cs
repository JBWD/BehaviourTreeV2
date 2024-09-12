using UnityEngine;
using Halcyon.BT;

namespace Halcyon.BT.Integrations.Combat
{
        [BehaviourTreeNode(menuPath = "Combat/Get", menuName = "Combat: Get Attack Script",
            nodeTitle = "Combat:\n Set Attack Script", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
    public class Combat_GetAttackScriptNode : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<GameObject> attacker;
        [BlackboardValueOnly]
        public NodeProperty<IAttack> attackScript;
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (attacker != null)
            {
                attackScript.Value = attacker.Value.GetComponent<IAttack>();
                if(attackScript.Value != null)
                    return State.Success;
            }
            return State.Failure;
        }
    }
}