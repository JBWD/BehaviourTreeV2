using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;


[BehaviourTreeNode(menuPath = "A-Star Pathfinding", nodeIcon = NodeIcons.ai, nodeTitle = "Move To Position")]
public class MoveToPosition : ActionNode
{
 

    protected override void OnStart()
    {
        context.InitializeAStar();
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        return State.Success;
    }
}
