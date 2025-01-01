using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Animator:\nPlay Animation")]
    [NodeMenuName("Animator: Play Animation")]
    [NodeMenuPath("Animator")]
    public class AnimatorPlayAnimationByNameNode : ActionNode
    {
        public NodeProperty<NumericProperty> layerIndex;
        public NodeProperty<string> animationName;

        private int stateID = 0;

        private string initialAnimationName = "";
        // Start is called once before the first execution of Update after the MonoBehaviour is created

        public override void OnInit()
        {
            stateID = Animator.StringToHash(animationName.Value);
            initialAnimationName = animationName.Value;
        }

        protected override void OnStart()
        {
            if (initialAnimationName != animationName.Value)
            {
                stateID = Animator.StringToHash(animationName.Value);
                initialAnimationName = animationName.Value;
            }
        }

        protected override void OnStop()
        {


        }

        protected override State OnUpdate()
        {
            if (context.animator == null)
            {
                return State.Failure;
            }

            if (context.animator.HasState(layerIndex.Value.IntegerValue, stateID))


                context.animator.Play(animationName.Value, layerIndex.Value.IntegerValue);

            return State.Success;
        }
    }
}