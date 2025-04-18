﻿using System;

namespace Halcyon.BT
{
    [NodeTitle("NavMesh:\n Start Movement")]
    [NodeMenuName("NavMesh: Start Movement")]
    [NodeMenuPath("NavMesh")]
    [NodeIcon(NodeIcons.ai)]
    [System.Serializable]
    public class NavMeshStartMovement : ActionNode
    {
        protected override void OnStart()
        {
           
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Failure;
            if (context.agent == null)
                return state;

            context.agent.isStopped = false;
            state = State.Success;

            return state;

            
        }

        public override void UpdateDescription()
        {
            description =
                "Starts the movement of the agent, call this node if you ever use the NavMesh: Stop Movement node.";
        }
    }
}