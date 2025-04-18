﻿using System.Linq.Expressions;
using UnityEngine;

namespace Halcyon.BT.RigidBody
{
    [NodeMenuPath("RigidBody")]
    [NodeTitle("RigidBody:\nAdd Force")]
    [NodeMenuName("RigidBody: Add Force")] 
    [CreateBBVariable("ForceDirectionValue", BBVariableType.Vector3)]
    
    [System.Serializable]
    public class RigidBodyAddForceNode : ActionNode
    {

        public ForceMode forceMode;
        public NodeProperty<Vector3> forceDirection;
        


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            context.rigidBody.useGravity = true;
            context.rigidBody.AddForce(forceDirection.Value, forceMode);
            state = State.Success;
            return state;
            
        }
        
    }
}