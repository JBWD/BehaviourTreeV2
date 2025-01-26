using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Animator")]
    [NodeMenuName("Animator: Set Layer Weight")]
    [NodeTitle("Animator:\nSet Layer Weight")]
    [NodeIcon(NodeIcons.animation)]
    [CreateBBVariable("LayerIndex", BBVariableType.Number)]
    [CreateBBVariable("LayerWeight", BBVariableType.Number)]
    [System.Serializable]
    public class AnimatorSetLayerWeightNode : ActionNode
    {
        public NodeProperty<NumericProperty> layerIndex;
        public NodeProperty<NumericProperty> layerWeight;




        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {

            if (context.animator == null)
            {
                state = State.Failure;
                return state;
            }

            context.animator.SetLayerWeight(layerIndex.Value.IntegerValue, layerWeight.Value.FloatValue);
            return state;
        }
        

        public override void UpdateDescription()
        {
            errored = false;
            if (Application.isPlaying)
            {
                if (context == null)
                    return;
                if (context.animator == null)
                {
                    description = $"Animator was not found on: {context.gameObject.name}";
                    errored = true;
                }
            }
            else
            {
                description = $"Sets the layer '{layerIndex.Value.IntegerValue}' to a weight of {layerWeight.Value.FloatValue}'";
            }
        }
    }
}