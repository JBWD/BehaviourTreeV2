
using System;
using Unity.Mathematics;
using UnityEngine;

namespace Halcyon.BT
{
    public class CharacterControllerApplyGravityNode : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<Vector3> Velocity;
        [BlackboardValueOnly]
        public NodeProperty<bool> IsGrounded;

        public NodeProperty<float> Gravity = new NodeProperty<float>(){Value = -9.81f};
        public NodeProperty<float> TerminalVelocity = new NodeProperty<float>() {Value = -2f};
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
            float y = Velocity.Value.y + Gravity.Value * Time.deltaTime;
            if (IsGrounded.Value)
            {
                y = TerminalVelocity.Value;
            }
            y = Math.Clamp(y, TerminalVelocity.Value, float.MaxValue);
            Velocity.Value = new Vector3(Velocity.Value.x, y, Velocity.Value.z);
            return State.Success;
        }
    }
}