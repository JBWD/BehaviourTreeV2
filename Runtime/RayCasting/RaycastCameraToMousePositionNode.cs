using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Raycasting", menuName = "Raycasting: Camera to Mouse Point", nodeTitle = "Raycasting:\nCamera to Mouse Point",
        nodeColor =  NodeColors.green, nodeIcon = NodeIcons.destination)]
    [System.Serializable]
    public class RaycastCameraToMousePositionNode : ActionNode
    {
        
        
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
            if (Camera.main != null)
            {
                var ray=  Camera.main.ScreenPointToRay(Input.mousePosition,Camera.MonoOrStereoscopicEye.Mono);
                Physics.Raycast(ray, out RaycastHit raycasthit);
                if (raycasthit.collider != null)
                {
                    Debug.Log(raycasthit.point);
                    saveHitCollider.Value = raycasthit.collider;
                    saveHitGameObject.Value = raycasthit.collider.gameObject;
                    saveHitPosition.Value = raycasthit.point;
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