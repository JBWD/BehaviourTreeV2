using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Animator")]
    [NodeMenuName("Animator: Get Layer Name")]
    [NodeTitle("Animator:\nGet Layer Name")]
    [NodeIcon(NodeIcons.animation)]
    [CreateBBVariable("LayerName", BBVariableType.String)]
    [CreateBBVariable("LayerIndex", BBVariableType.Number)]
    [System.Serializable]
    public class AnimatorGetLayerNameNode : ActionNode
    {
        
        
        public NodeProperty<NumericProperty> layerIndex;
        [BlackboardValueOnly]
        public NodeProperty<string> saveName;




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

            saveName.Value = context.animator.GetLayerName(layerIndex.Value.IntegerValue);
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
                if (saveName.reference != null)
                {
                    description =
                        $"Retrieves the layer '{layerIndex.Value.IntegerValue}' name and saves the value in '{saveName.reference.name}'";
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