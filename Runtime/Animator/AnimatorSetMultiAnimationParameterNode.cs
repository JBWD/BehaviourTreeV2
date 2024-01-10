﻿using System.Collections.Generic;
using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Animator", menuName = "Animator: Set Multi Parameter", nodeColor = NodeColors.green,nodeIcon = NodeIcons.animation,nodeTitle = "Animator:\nSet Multi Parameter")]
    [System.Serializable]
    public class AnimatorSetMultiAnimationParameterNode: ActionNode
    {
        public List<AnimationProperty> animationProperties;
        
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

            foreach (var animationProperty in animationProperties)
            {
                switch (animationProperty.parameterType)
                {
                    case AnimationParameterType.Boolean:
                        context.animator.SetBool(animationProperty.animationName, animationProperty.booleanParameter);
                        state = State.Success;
                        break;
                    case AnimationParameterType.Float:
                        context.animator.SetFloat(animationProperty.animationName, animationProperty.floatParameter);
                        state = State.Success;
                        break;
                    case AnimationParameterType.Integer:
                        context.animator.SetInteger(animationProperty.animationName,
                            animationProperty.integerParameter);
                        state = State.Success;
                        break;
                    case AnimationParameterType.Trigger:
                        context.animator.SetTrigger(animationProperty.animationName);
                        state = State.Success;
                        break;
                    default:
                        state = State.Failure;
                        break;
                }
            }

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
            description = "Animation Name does not have a value:";
            var length = description.Length;
            for (var index = 0; index < animationProperties.Count; index++)
            {
                var animationProperty = animationProperties[index];
                if (animationProperty.animationName == "")
                {
                    description += $"[{index}] ";
                    errored = true;
                }
            }

            if (length < description.Length)
                return;


            description = "Sets all of the parameters in the animator to their corresponding values.";

            
        }
    }
}