using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform/Get")]
    [NodeTitle("Transform:\nGet Local Position")]
    [NodeMenuName("Transform: Get Local Position")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("SaveVector3Value", BBVariableType.Vector3)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [System.Serializable]
    public class TranformGetLocalPositionNode :ActionNode
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
                saveValue.Value = context.transform.localPosition;
            }
            else
            {
                state = State.Success;
                saveValue.Value = transformValue.Value.localPosition;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;

            description = "Retrieves the position of the object in Local Space and saves the position in [SaveValue]";

            if (saveValue.reference == null)
            {
                description = "Unable to save value.";
            }
        }
    }
}