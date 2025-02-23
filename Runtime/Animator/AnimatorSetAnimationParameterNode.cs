using System;
using UnityEngine;

namespace Halcyon.BT
{
  
    [NodeTitle("Animator:\nSet Parameter")]
    [NodeMenuName("Animator: Set Parameter")]
    [NodeMenuPath("Animator")]
    [System.Serializable]
    public class AnimatorSetAnimationParameterNode: ActionNode
    {
        public AnimationProperty animationProperty;
        
        public override void OnInit()
        {
            
            
        }


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

            switch (animationProperty.parameterType)
            {
                case AnimationParameterType.Boolean:
                    context.animator.SetBool(animationProperty.parameterName.Value, animationProperty.booleanParameter.Value);
                    state = State.Success;
                    break;
                case AnimationParameterType.Float:
                    context.animator.SetFloat(animationProperty.parameterName.Value, animationProperty.floatParameter.Value.FloatValue);
                    state = State.Success;
                    break;
                case AnimationParameterType.Integer:
                    context.animator.SetInteger(animationProperty.parameterName.Value, animationProperty.integerParameter.Value.IntegerValue);
                    state = State.Success;
                    break;
                case AnimationParameterType.Trigger:
                    context.animator.SetTrigger(animationProperty.parameterName.Value);
                    state = State.Success;
                    break;
                default:
                    state = State.Failure;
                    break;
            }

            return state;
        }

        public override void UpdateDescription()
        {
            base.UpdateDescription();
            
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
                if (animationProperty.parameterName.Value == "")
                {
                    description = "Parameter Name is not value";
                    errored = true;
                    return;
                }

                switch (animationProperty.parameterType)
                {
                    case AnimationParameterType.Boolean:
                        description =
                            $"Setting boolean parameter  to '{animationProperty.booleanParameter}'";
                        break;
                    case AnimationParameterType.Float:
                        description = $"Setting float parameter '{animationProperty.parameterName}' to '{animationProperty.floatParameter}'";
                        break;
                    case AnimationParameterType.Integer:
                        description =
                            $"Setting integer parameter '{animationProperty.parameterName}' to '{animationProperty.integerParameter}'";
                        break;
                    case AnimationParameterType.Trigger:
                        description = $"Firing trigger parameter '{animationProperty.parameterName}'";
                        break;
                }
            }
        }
    }
}