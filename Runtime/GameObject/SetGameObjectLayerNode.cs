using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "GameObject", nodeColor = NodeColors.pink,nodeIcon = NodeIcons.none, nodeTitle = "Set Layer")]
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