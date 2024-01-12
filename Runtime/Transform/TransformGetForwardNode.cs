using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Transform/Get", menuName = "Transform: Get Forward", nodeTitle = "Transform:\n Get Forward",
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
    [System.Serializable]
    public class TranformGetForwardNode :ActionNode
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
                saveValue.Value = context.transform.forward;
            }
            else
            {
                state = State.Success;
                saveValue.Value = transformValue.Value.forward;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;

            description = "Retrieves the forward direction of the object in World Space and saves the forward direction in [SaveValue]";

            if (saveValue.reference == null)
            {
                description = "Unable to save value.";
            }
        }
    }
}