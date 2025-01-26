using UnityEngine;
using UnityEngine.Serialization;

namespace Halcyon.BT
{
    [NodeMenuPath( "GameObject/Get" )]
    [NodeTitle("GameObject:\nSet Layer")]
    [NodeMenuName("GameObject: Set Layer")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.save)]
    [CreateBBVariable("GameObject", BBVariableType.GameObject)]
    [CreateBBVariable("LayerIndex", BBVariableType.Number)]
    [System.Serializable]
    public class SetGameObjectLayerNode : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<GameObject> gameObject; 
        public bool self = true;
        public NodeProperty<NumericProperty> LayerIndex;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            state = State.Failure;
            if(!self)
            {
                if(gameObject != null)
                {
                    LayerIndex.Value.IntegerValue = gameObject.Value.layer;
                    state = State.Success;
                }
            }
            
            if (state == State.Success)
                return state;

            if (gameObject.Value != null)
            {
                gameObject.Value.layer = LayerIndex.Value.IntegerValue;
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
            
            description = $"Sets the 'GameObject's active state to '{LayerIndex.Value.IntegerValue}'.";
        }
    }
}