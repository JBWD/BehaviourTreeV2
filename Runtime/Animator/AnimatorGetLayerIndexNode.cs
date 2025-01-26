using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Animator")]
    [NodeMenuName("Animator: Get Layer Index")]
    [NodeTitle("Animator:\nGet Layer Index")]
    [NodeIcon(NodeIcons.animation)]
    [CreateBBVariable("LayerName", BBVariableType.String)]
    [CreateBBVariable("LayerIndex", BBVariableType.Number)]
    [System.Serializable]
    public class AnimatorGetLayerIndexNode : ActionNode
    {

        public NodeProperty<string> layerName;
        [BlackboardValueOnly]
        public NodeProperty<NumericProperty> saveIndex;




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

            saveIndex.Value.IntegerValue = context.animator.GetLayerIndex(layerName.Value);
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
                if (saveIndex.reference != null)
                {
                    description =
                        $"Retrieves the layer '{layerName.Value}' index and saves the value in '{saveIndex.reference.name}'";
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