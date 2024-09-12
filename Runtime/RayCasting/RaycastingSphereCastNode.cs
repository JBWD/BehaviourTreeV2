using UnityEditor;
using UnityEngine;

namespace Halcyon.BT
{
    [System.Serializable]
    public class RaycastingSphereCastNode:ActionNode
    {
        public LayerMask hitLayers;

        public float sphereRadius;
        public Vector3 positionOffset;
        public float castDistance = 1f;
        
        [BlackboardValueOnly]
        public NodeProperty<Vector3> saveHitPosition;
        [BlackboardValueOnly]
        public NodeProperty<Collider> saveHitCollider;
        [BlackboardValueOnly]
        public NodeProperty<GameObject> saveHitGameObject;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Failure;
            if (context.transform != null)
            {
                
                Physics.SphereCast(new Ray(context.transform.position + positionOffset, context.transform.forward * castDistance)
                    ,sphereRadius, out RaycastHit raycasthit, castDistance);
                if (raycasthit.collider != null)
                {
                    Debug.Log(raycasthit.collider.name);
                    if ((hitLayers & (1 << raycasthit.collider.gameObject.layer)) != 0)
                    {
                        saveHitCollider.Value = raycasthit.collider;
                        saveHitGameObject.Value = raycasthit.collider.gameObject;
                        saveHitPosition.Value = raycasthit.point;
                        state = State.Success;
                    }
                }
            }
            


            return state;
        }

        public override void OnDrawGizmos()
        {
            if (context.transform != null)
            {
                Gizmos.DrawWireSphere(context.transform.position + positionOffset, sphereRadius);
            }
            
        }
        
    }
}