using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "GameObject/Set", menuName = "GameObject: Set Layer", nodeColor = NodeColors.pink,
        nodeIcon = NodeIcons.none, nodeTitle = "GameObject:\nSet Layer")]
    [System.Serializable]
    public class SetGameObjectLayerNode : ActionNode
    {
        
        public NodeProperty<GameObject> gameObject;
        public NodeProperty<LayerMask> layer;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (gameObject.Value != null)
            {
                gameObject.Value.layer = layer.Value.value;
                state = State.Success;
            }
            else
            {
                state = State.Failure;
            }

            return state;
        }
    }
}