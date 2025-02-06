using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform/Get")]
    [NodeTitle("Transform:\nGet Right")]
    [NodeMenuName("Transform: Get Right")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [CreateBBVariable("SaveVector3Value", BBVariableType.Vector3)]
    [System.Serializable]
    public class TransformGetRightNode : ActionNode
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
                saveValue.Value = context.transform.right;
            }
            else
            {
                saveValue.Value = transformValue.Value.right;
            }
            

            state = State.Success;
            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;

            description = "Retrieves the Right Direction of the object in World Space and saves the Right Direction in [SaveValue]";

            if (saveValue.reference == null)
            {
                description = "Unable to save value.";
            }
        }
    }
}