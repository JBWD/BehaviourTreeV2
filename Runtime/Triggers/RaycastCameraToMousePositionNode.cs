using UnityEngine;

namespace TheKiwiCoder
{
    public class RaycastCameraToMousePositionNode : ActionNode
    {
        public NodeProperty<Vector3> mouseHitPosition;
        public NodeProperty<Collider> hitCollider;
        public NodeProperty<GameObject> hitGameObject;
            
        
        
        
        
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (Camera.main != null)
            {
                var ray=  Camera.main.ScreenPointToRay(Input.mousePosition,Camera.MonoOrStereoscopicEye.Mono);
                Physics.Raycast(ray, out RaycastHit raycasthit);
                if (raycasthit.collider != null)
                {
                    Debug.Log(raycasthit.point);
                    hitCollider.Value = raycasthit.collider;
                    hitGameObject.Value = raycasthit.collider.gameObject;
                    mouseHitPosition.Value = raycasthit.point;
                    state = State.Success;
                }
            }
            else
            {
                state = State.Failure;
            }


            return state;
        }
    }
}