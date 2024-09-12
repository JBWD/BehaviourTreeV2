using Halcyon.BT;
using UnityEngine;

namespace Halcyon.BT.Integrations.Combat
{
    
    [BehaviourTreeNode(menuPath = "Combat/Get", menuName = "Combat: Get Current Health",
        nodeTitle = "Combat:\n Get Current Health", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
    public class Combat_GetCurrentHealthNode : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<float> saveValue;


        protected override void OnStart()
        {
           
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (saveValue.reference == null)
                return State.Failure;
            return State.Success;
        }

        public override void UpdateDescription()
        {
            errored = false;
            if (saveValue.reference == null)
            {
                description = "Does not save any of the values";
                errored = true;
            }
            else
            {
                description = "Sets the 'SaveValue' to the CombatContext CurrentHealth value.";
            }
        }
    }
}

