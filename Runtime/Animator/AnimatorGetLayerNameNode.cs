using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Animator",menuName = "Animator: Get Layer Name", nodeTitle = "Animator:\nGet Layer Name", nodeColor = NodeColors.green, nodeIcon = NodeIcons.animation)]
    [System.Serializable]
    public class AnimatorGetLayerNameNode : ActionNode
    {
        
        
        public NodeProperty<int> layerIndex;
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

            saveName.Value = context.animator.GetLayerName(layerIndex.Value);
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
                        $"Retrieves the layer '{layerIndex.Value}' name and saves the value in '{saveName.reference.name}'";
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