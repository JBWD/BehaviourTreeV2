using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Animator")]
    [NodeMenuName("Animator: Get Layer Weight")]
    [NodeTitle("Animator:\nGet Layer Weight")]
    [NodeIcon(NodeIcons.animation)]
    [CreateBBVariable("LayerIndex", BBVariableType.Number)]
    [CreateBBVariable("LayerWeight", BBVariableType.Number)]
    [System.Serializable]
    public class AnimatorGetLayerWeightNode : ActionNode
    {
        public NodeProperty<NumericProperty> layerIndex;
        [BlackboardValueOnly]
        public NodeProperty<NumericProperty> saveWeight;




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

            saveWeight.Value.FloatValue = context.animator.GetLayerWeight(layerIndex.Value.IntegerValue);
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
                if (saveWeight.reference != null)
                {
                    description =
                        $"Retrieves the layer '{layerIndex.Value.IntegerValue}' index and saves the value in '{saveWeight.reference.name}'";
                }
                else
                {
                    description =
                        $"Does not save the value";
                    errored = true;
                }
            }
        }
    }
}