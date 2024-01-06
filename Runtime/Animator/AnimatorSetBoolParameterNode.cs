

using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode("Animator","Set Bool Parameter", "Animator:\nSet Bool Parameter", nodeIcon = NodeIcons.animation, nodeColor = NodeColors.green)]
    [System.Serializable]
    public class AnimatorSetBoolParameterNode : ActionNode
    {
        public NodeProperty<string> boolParameterName;
        public NodeProperty<bool> booleanState;
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
            }
            else
            {
                context.animator.SetBool(boolParameterName.Value, booleanState.Value);
                state = State.Success;
            }

            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;

            description = $"Set's the Animators parameter '{boolParameterName.Value}' to {booleanState.Value}.";

            if (Application.isPlaying)
            {
                if (context == null)
                    return;
                
                if (context.animator == null)
                {
                    errored = true;
                    description =
                        $"Unable to located Animator in {context.gameObject}, please verify it has been added.";
                }
            }
        }
    }
}