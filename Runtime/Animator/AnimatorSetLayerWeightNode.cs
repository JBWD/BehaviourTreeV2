using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Animator",menuName = "Animator: Set Layer Weight", nodeTitle = "Animator:\nSet Layer Weight", nodeColor = NodeColors.green, nodeIcon = NodeIcons.animation)]
    [System.Serializable]
    public class AnimatorSetLayerWeightNode : ActionNode
    {
        public NodeProperty<int> layerIndex;
        public NodeProperty<float> layerWeight;




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

            context.animator.SetLayerWeight(layerIndex.Value, layerWeight.Value);
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
                description = $"Sets the layer '{layerIndex.Value}' to a weight of {layerWeight.Value}'";
            }
        }
    }
}