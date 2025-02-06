using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform/Set")]
    [NodeTitle("Transform:\nSet Parent")]
    [NodeMenuName("Transform: Set Parent")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [CreateBBVariable("ParentValue", BBVariableType.Transform)]
    [System.Serializable]
    public class TranformSetParentNode :ActionNode
    {
        public NodeProperty<Transform> transformValue;
        public bool self = true;
        public NodeProperty<Transform> parent;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (parent.Value == null)
            {
                state = State.Failure;
                return state;
            }
                
            if (self && context.transform != null)
            {
                context.transform.SetParent(parent.Value);
                state = State.Success;
            }
            if (transformValue.Value!= null)
            {

                transformValue.Value.SetParent(parent.Value);
                state = State.Success;
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
            description = $"Sets the [TransformValue] Parent to [ParentValue].";

            if (parent.reference == null)
            {
                errored = true;
                description = "Unable to locate [ParentValue].";
            }
        }
    }
}