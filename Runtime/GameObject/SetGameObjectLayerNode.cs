using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "GameObject/Set", menuName = "GameObject: Set Layer", nodeColor = NodeColors.pink,
        nodeIcon = NodeIcons.none, nodeTitle = "GameObject:\nSet Layer")]
    [System.Serializable]
    public class SetGameObjectLayerNode : ActionNode
    {
        
        public NodeProperty<GameObject> gameObject;
        public NodeProperty<LayerMask> layerMask;
        
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
                gameObject.Value.layer = layerMask.Value;
                state = State.Success;
            }
            else
            {
                state = State.Failure;
            }

            return state;
        }
        public override void UpdateDescription()
        {
            
            description = $"Sets the 'GameObject's active state to '{layerMask.Value}'.";
        }
    }
}