using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;


[BehaviourTreeNode(menuPath = "A-Star Pathfinding", nodeIcon = NodeIcons.ai, nodeTitle = "Move To Position", nodeColor = NodeColors.green)]
public class MoveToPosition : ActionNode
{

    public NodeProperty<Vector3> moveToPosition;


    protected override void OnStart()
    {
        context.InitializeAStar();
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (context.aiPath == null)
        {
            state = State.Failure;
        }
        else
        {
            description = "test";
            context.aiPath.destination = moveToPosition.Value;
            state = State.Success;
        }
        
        
        
        return state;
    }
}
