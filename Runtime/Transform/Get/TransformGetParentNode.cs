using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform/Get")]
    [NodeTitle("Transform:\nGet Parent")]
    [NodeMenuName("Transform: Get Parent")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [CreateBBVariable("SaveTransformValue", BBVariableType.Transform)]
    [System.Serializable]
    public class TranformGetParentNode :ActionNode
    {

        public NodeProperty<Transform> transformValue;
        public bool self = true;
        [BlackboardValueOnly] public NodeProperty<Transform> saveValue;

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
                saveValue.Value = context.transform.parent;
            }
            else
            {
                state = State.Success;
                saveValue.Value = transformValue.Value.parent;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;

            description = "Retrieves the parent of the object and saves the parent in [SaveValue]";

            if (saveValue.reference == null)
            {
                description = "Unable to save value.";
            }
        }
    }
}