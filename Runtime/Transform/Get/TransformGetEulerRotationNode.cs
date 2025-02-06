using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform/Get")]
    [NodeTitle("Transform:\nGet Euler Rotation")]
    [NodeMenuName("Transform: Get Euler Rotation")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("SaveVector3Value", BBVariableType.Vector3)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [System.Serializable]
    public class TransformGetEulerRotationNode : ActionNode
    {
        public NodeProperty<Transform> transformValue;
        public bool self = true;
        [BlackboardValueOnly]
        public NodeProperty<Vector3> saveValue;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (self || transformValue.Value == null)
            {
                saveValue.Value = context.transform.eulerAngles;
            }
            else
            {
                saveValue.Value = transformValue.Value.eulerAngles;
            }
            

            state = State.Success;
            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;

            description = "Retrieves the Euler Rotation of the object in World Space and saves the Euler Rotation in [SaveValue]";

            if (saveValue.reference == null)
            {
                description = "Unable to save value.";
            }
        }
    }
}