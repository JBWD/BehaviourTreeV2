using Halcyon.BT;
using Halcyon.BT.Integrations.Pathlist;
using UnityEngine;

namespace Halcyon.BT
{
    
    [NodeTitle("PathList:\n Traverse Path List")]
    [NodeMenuName("PathList: Traverse Path List")]
    [NodeMenuPath("Integrations/PathList")]
    [NodeIcon(NodeIcons.destination)]
    public class TraversePathListNode : ActionNode
    {
        public NodeProperty<bool> loop = new NodeProperty<bool>() {Value = true};
        public NodeProperty<PathListProperty> pathList;
        private int currentPathIndex = 0;
        private float timeDelayed = 0;
        
        
        
        protected override void OnStart()
        {
            currentPathIndex = 0;
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
            PathListProperty.PathPoint pathPoint = pathList.Value.PathPoints[currentPathIndex];
            Vector3 newPosition = Vector3.MoveTowards(context.transform.position, pathPoint.point, Time.deltaTime * pathPoint.moveSpeed);
            
            context.transform.position = newPosition;

            if (Vector3.Distance(pathPoint.point, context.transform.position) < 0.1f)
            {

                if (pathPoint.delayAtPoint > 0 && timeDelayed < pathPoint.delayAtPoint)
                {
                    timeDelayed += Time.deltaTime;
                }
                else
                {
                    currentPathIndex++;
                    timeDelayed = 0;
                    if (currentPathIndex >= pathList.Value.PathPoints.Count)
                    {
                        currentPathIndex = pathList.Value.PathPoints.Count - 1;
                        if(loop.Value)
                            currentPathIndex = 0;
                        else
                        {
                            return State.Success;
                        }
                    }
                }
            }
            
            return State.Running;
        }
    }
}