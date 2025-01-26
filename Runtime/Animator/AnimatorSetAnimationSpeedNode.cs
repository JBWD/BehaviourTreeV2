using UnityEngine;
using UnityEngine.Serialization;

namespace Halcyon.BT
{
    
   
    [NodeTitle("Animator:\nSet Playback Speed")]
    [NodeMenuName("Animator: Set Playback Speed")]
    [NodeMenuPath("Animator")]
    [CreateBBVariable("PlaybackSpeed", BBVariableType.Number)]
    [System.Serializable]
    public class AnimatorSetAnimationSpeedNode:ActionNode
    {
        public NodeProperty<NumericProperty> playbackSpeed;




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

            context.animator.speed = playbackSpeed.Value.FloatValue;
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
                description = $"Sets the animation playback speed to: '{playbackSpeed.Value}'";
            }
        }
#endif
        
    }
}