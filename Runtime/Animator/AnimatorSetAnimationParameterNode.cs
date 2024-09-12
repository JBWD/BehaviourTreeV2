﻿using System;
using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Animator", menuName = "Animator: Set Parameter", nodeColor = NodeColors.green,nodeIcon = NodeIcons.animation,nodeTitle = "Animator:\nSet Parameter")]
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
                    context.animator.SetBool(animationProperty.animationName, animationProperty.booleanParameter);
                    state = State.Success;
                    break;
                case AnimationParameterType.Float:
                    context.animator.SetFloat(animationProperty.animationName, animationProperty.floatParameter);
                    state = State.Success;
                    break;
                case AnimationParameterType.Integer:
                    context.animator.SetInteger(animationProperty.animationName, animationProperty.integerParameter);
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
                if (animationProperty.animationName == "")
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
                        description = $"Setting float parameter '{animationProperty.animationName}' to '{animationProperty.floatParameter}'";
                        break;
                    case AnimationParameterType.Integer:
                        description =
                            $"Setting integer parameter '{animationProperty.animationName}' to '{animationProperty.integerParameter}'";
                        break;
                    case AnimationParameterType.Trigger:
                        description = $"Firing trigger parameter '{animationProperty.animationName}'";
                        break;
                }
            }
        }
    }
}