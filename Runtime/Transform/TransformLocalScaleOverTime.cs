using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform")]
    [NodeTitle("Transform:\nScale Over Time")]
    [NodeMenuName("Transform: Scale Over Time")]
    [NodeIcon(NodeIcons.time)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [CreateBBVariable("TimeInSeconds", BBVariableType.Number)]
    [CreateBBVariable("EndingScale", BBVariableType.Vector3)]
    [System.Serializable]
    public class TransformLocalScaleOverTime : ActionNode
    {

        public NodeProperty<Transform> transformValue;
        public bool self = true;
        public NodeProperty<NumericProperty> timeInSeconds;
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

            if (timeInSeconds.Value.FloatValue < 0)
            {
                timeInSeconds.Value.FloatValue *= -1;
            }
            
            if(timeInSeconds.Value.FloatValue != 0)
                
                scaleSpeed = 1 / timeInSeconds.Value.FloatValue;
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
            description = $"Sets the Local Scale of the object over {timeInSeconds.Value.FloatValue} at a linear speed.";

        }
    }
}