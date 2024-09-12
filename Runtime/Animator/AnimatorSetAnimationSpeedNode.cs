using UnityEngine;

namespace Halcyon.BT
{
    
    [BehaviourTreeNode(menuPath = "Animator", menuName = "Animator: Set Playback Speed",nodeTitle = "Animator:\nSet Playback Speed", nodeColor = NodeColors.green,nodeIcon = NodeIcons.animation)]
    [System.Serializable]
    public class AnimatorSetAnimationSpeedNode:ActionNode
    {
        public NodeProperty<float> playBackSpeed;




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

            context.animator.speed = playBackSpeed.Value;
            state = State.Success;
            return state;
        }
        
#if UNITY_EDITOR
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
                description = $"Sets the animation playback speed to: '{playBackSpeed.Value}'";
            }
        }
#endif
        
    }
}