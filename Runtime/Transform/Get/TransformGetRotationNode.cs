using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform/Get")]
    [NodeTitle("Transform:\nGet Rotation")]
    [NodeMenuName("Transform: Get Rotation")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [CreateBBVariable("SaveQuaternionValue", BBVariableType.Quaternion)]
    [System.Serializable]
    public class TransformGetRotationNode : ActionNode
    {
        
        public NodeProperty<Transform> transformValue;
        public bool self = true;
        [BlackboardValueOnly]
        public NodeProperty<Quaternion> saveValue;


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
                saveValue.Value = context.transform.rotation;
            }
            else if(transformValue.Value != null)
            {
                saveValue.Value = transformValue.Value.rotation;
            }
            else
            {
                state = State.Failure;
            }

            return state;
        }
    }
}