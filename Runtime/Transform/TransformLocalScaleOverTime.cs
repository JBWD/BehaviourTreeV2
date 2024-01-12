using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Transform", menuName = "Transform: Scale Over Time", nodeTitle = "Transform:\nScale Over Time",
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.time)]
    [System.Serializable]
    public class TransformLocalScaleOverTime : ActionNode
    {

        public NodeProperty<Transform> transformValue;
        public bool self = true;
        public NodeProperty<float> timeInSeconds;
        public NodeProperty<Vector3> endingScale;

        private float scaleSpeed;
        private Vector3 startValue;
        private float interpellationPoint;


        protected override void OnStart()
        {
            interpellationPoint = 0;
            if (self && context.transform != null)
            {
                startValue = context.transform.localScale;
            }
            else if(transformValue.Value != null)
            {
                startValue = transformValue.Value.localScale;
            }

            if (timeInSeconds.Value < 0)
            {
                timeInSeconds.Value *= -1;
            }
            
            if(timeInSeconds.Value != 0)
                
                scaleSpeed = 1 / timeInSeconds.Value;
            else
            {
                scaleSpeed = 1000000000;
            }

            if (startValue != endingScale.Value)
            {
                state = State.Running;
            }
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            
            interpellationPoint += scaleSpeed * Time.deltaTime;
            
            if (self && context.transform != null)
            {
                if (interpellationPoint > 1)
                {
                    context.transform.localScale = endingScale.Value;
                    state = State.Success;
                }
                else
                {
                    context.transform.localScale = Vector3.Lerp(startValue, endingScale.Value, interpellationPoint);
                }
            }
            else if(transformValue.Value != null)
            {
                if (interpellationPoint > 1)
                {
                    transformValue.Value.localScale = endingScale.Value;
                    state = State.Success;
                }
                else
                {
                    transformValue.Value.localScale = Vector3.Lerp(startValue, endingScale.Value, interpellationPoint);
                }
            }
            else
            {
                state = State.Failure;
            }

            return state;

        }
        
        public override void UpdateDescription()
        {
            description = $"Sets the Local Scale of the object over {timeInSeconds.Value} at a linear speed.";

        }
    }
}