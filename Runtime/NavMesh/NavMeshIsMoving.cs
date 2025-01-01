using UnityEngine;

namespace Halcyon.BT
{
    
    [BehaviourTreeNode(menuPath = "NavMesh", menuName = "NavMesh: Is Agent Moving", nodeTitle = "NavMesh:\n Is Agent Moving", nodeColor = NodeColors.yellow, nodeIcon = NodeIcons.condition)]
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