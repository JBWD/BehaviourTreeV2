using UnityEngine;

namespace Halcyon.BT
{
    
    [NodeTitle("NavMesh:\n Is Moving")]
    [NodeMenuName("NavMesh: Is Moving")]
    [NodeMenuPath("NavMesh")] 
    [System.Serializable]
    public class NavMeshIsMoving : ComparisonNode
    {
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }


        public override bool CheckComparison()
        {
            return context.agent.remainingDistance > context.agent.stoppingDistance && !context.agent.isStopped;
        }

        public override void UpdateDescription()
        {
            
        }
        
    }
}