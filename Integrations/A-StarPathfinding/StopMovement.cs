using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using TheKiwiCoder;
using UnityEngine;

namespace TheKiwiCoder
{


    public class StopMovement : ActionNode
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
            if (context.aiPath == null)
            {
                Debug.LogWarning("Unable to find Context.aiPath, Please make sure there is an AIPath if using the " +
                                 "StopMovement Node");
                state = State.Failure;
            }
            else
            {
                context.aiPath.isStopped = true;
                state = State.Success;
            }
            
            return state;

        }
    }

}