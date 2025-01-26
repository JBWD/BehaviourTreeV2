using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Raycasting", menuName = "Raycasting: Camera to Mouse Point", nodeTitle = "Raycasting:\nCamera to Mouse Point",
        nodeColor =  NodeColors.green, nodeIcon = NodeIcons.destination)]
    [NodeTitle("Raycasting:\nCamera to Mouse Point")]
    [NodeMenuName("Raycasting: Camera to Mouse Point")]
    [NodeMenuPath("Raycasting")]
    [NodeIcon(NodeIcons.destination)]
    [CreateBBVariable("SaveHitPosition", BBVariableType.Vector3)]
    [CreateBBVariable("SaveHitCollider", BBVariableType.Collider)]
    [CreateBBVariable("SaveHitGameObject", BBVariableType.GameObject)]
    [CreateBBVariable("SaveHitTransform", BBVariableType.Transform)]
    [System.Serializable]
    public class RaycastCameraToMousePositionNode : ActionNode
    {
        
        public LayerMask hitLayers;

        
        [BlackboardValueOnly]
        public NodeProperty<Vector3> saveHitPosition;
        [BlackboardValueOnly]
        public NodeProperty<Collider> saveHitCollider;
        [BlackboardValueOnly]
        public NodeProperty<GameObject> saveHitGameObject;
        [BlackboardValueOnly]
        public NodeProperty<Transform> saveHitTransform;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Failure;
            if (Camera.main != null)
            {
                var ray=  Camera.main.ScreenPointToRay(Input.mousePosition,Camera.MonoOrStereoscopicEye.Mono);
                Physics.Raycast(ray, out RaycastHit raycasthit);
                if (raycasthit.collider != null)
                {
                    
                    if ((hitLayers & (1 << raycasthit.collider.gameObject.layer)) != 0)
                    {
                        saveHitCollider.Value = raycasthit.collider;
                        saveHitGameObject.Value = raycasthit.collider.gameObject;
                        saveHitPosition.Value = raycasthit.point;
                        saveHitTransform.Value = raycasthit.collider.transform;
                        state = State.Success;
                    }
                }
            }
            


            return state;
        }
        
        
    }
}