using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Animator",menuName = "Animator: Get Layer Index", nodeTitle = "Animator:\nGet Layer Index", nodeColor = NodeColors.green, nodeIcon = NodeIcons.animation)]
    [System.Serializable]
    public class AnimatorGetLayerIndexNode : ActionNode
    {

        public NodeProperty<string> layerName;
        [BlackboardValueOnly]
        public NodeProperty<int> saveIndex;




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

            saveIndex.Value = context.animator.GetLayerIndex(layerName.Value);
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