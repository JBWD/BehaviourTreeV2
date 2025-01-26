
using UnityEngine;

namespace Halcyon.BT
{
    
    [NodeTitle("NavMesh AI:\nHas Condition")]
    [NodeMenuPath("NavMesh/AI")]
    [NodeMenuName("NavMesh AI: Has Condition")]
    public class NavMeshHasConditionNode : ComparisonNode
    {

        public AIConditions conditions;


        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        public override bool CheckComparison()
        {
            return ((context.CurrentConditions & conditions) == conditions);
        }
    }
}