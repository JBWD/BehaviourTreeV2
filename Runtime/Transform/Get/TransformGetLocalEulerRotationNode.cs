using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform/Get")]
    [NodeTitle("Transform:\nGet Local Euler Rotation")]
    [NodeMenuName("Transform: Get Local Euler Rotation")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("SaveVector3Value", BBVariableType.Vector3)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [System.Serializable]
    public class TranformGetLocalEulerRotationNode :ActionNode
    {
        public NodeProperty<Transform> transformValue;
        public bool self = true;
        [BlackboardValueOnly] public NodeProperty<Vector3> saveValue;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Failure;

            
            if (self && context.transform != null)
            {
                state = State.Success;
                saveValue.Value = context.transform.localEulerAngles;
            }
            else
            {
                state = State.Success;
                saveValue.Value = transformValue.Value.localEulerAngles;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;

            description = "Retrieves the Local Euler Rotation of the object and saves the Local Euler Rotation in [SaveValue]";

            if (saveValue.reference == null)
            {
                description = "Unable to save value.";
            }
        }
    }
}