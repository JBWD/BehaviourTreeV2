using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform")]
    [NodeTitle("Transform:\nLook At")]
    [NodeMenuName("Transform: Look At")]
    [NodeIcon(NodeIcons.ai)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [CreateBBVariable("LookAtTransform", BBVariableType.Transform)]
    [System.Serializable]
    public class TransformLookAtNode : ActionNode
    {
        public NodeProperty<Transform> transformValue;
        public bool self = true;
        [BlackboardValueOnly]
        public NodeProperty<Transform> lookAtValue;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;
            
            if (self && context.transform != null)
            {
                context.transform.LookAt(lookAtValue.Value, context.transform.up);
            }
            else if (lookAtValue.Value != null)
            {
                transformValue.Value.LookAt(lookAtValue.Value, lookAtValue.Value.up);
            }
            else
            {
                state = State.Failure;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;
            description = "Changes the rotation of the Transform and the forward direction to be pointing at the [LookAtValue]";

            if (lookAtValue.reference == null)
            {
                description = "Unable to locate [LookAtValue]";
                errored = true;
            }
        }
    }
}