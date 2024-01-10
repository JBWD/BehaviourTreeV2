using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Animator",menuName = "Animator: Get Layer Weight", nodeTitle = "Animator:\nGet Layer Weight", nodeColor = NodeColors.green, nodeIcon = NodeIcons.animation)]
    [System.Serializable]
    public class AnimatorGetLayerWeightNode : ActionNode
    {
        public NodeProperty<int> layerIndex;
        public NodeProperty<float> saveWeight;




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

            saveWeight.Value = context.animator.GetLayerWeight(layerIndex.Value);
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
                        $"Retrieves the layer '{layerIndex.Value}' index and saves the value in '{saveWeight.reference.name}'";
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