using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "GameObject/Get", menuName = "GameObject: Get Layer", nodeColor = NodeColors.pink,
        nodeIcon = NodeIcons.save, nodeTitle = "GameObject:\nGet Layer")]
    [System.Serializable]
    public class GetGameObjectLayerNode :ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<LayerMask> layerValue;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (context.gameObject != null)
            {
                layerValue.Value = context.gameObject.layer;
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
            
            description = $"Retrieves the gameObjects LayerMask and saves it in [LayerValue].";
        }
    }
}