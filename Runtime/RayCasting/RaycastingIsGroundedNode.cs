using UnityEngine;

namespace Halcyon.BT
{


    public class RaycastingIsGroundedNode : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<bool> IsGrounded;
        [Space]
        [Header("Raycast Settings")] public bool self = true;
        [BlackboardValueOnly] public NodeProperty<Transform> RaycastOrigin;
        public NodeProperty<Vector3> RaycastOffset = new NodeProperty<Vector3>(){ Value = new Vector3(0,.1f,0) };
        public NodeProperty<NumericProperty> RaycastLength = new NodeProperty<NumericProperty>();
        public NodeProperty<LayerMask> GroundLayer;


        // Update is called once per frame
        protected override void OnStart()
        {
           
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (Physics.Raycast((self ? context.transform.position : RaycastOrigin.Value.position) + RaycastOffset.Value, Vector3.down,
                    RaycastLength.Value.FloatValue, GroundLayer.Value))
            {
                IsGrounded.Value = true;
                return State.Success;
            }

            IsGrounded.Value = false;
            return State.Failure;
        }

        public override void OnDrawGizmos()
        {
            Debug.DrawRay((self ? context.transform.position : RaycastOrigin.Value.position ) + RaycastOffset.Value, Vector3.down * RaycastLength.Value.FloatValue, Color.yellow);
        }
    }
}