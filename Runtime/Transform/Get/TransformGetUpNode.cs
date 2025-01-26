using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Transform/Get", menuName = "Transform: Get Up", nodeTitle = "Transform:\nGet Up",
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
    [System.Serializable]
    public class TransformGetUpNode : ActionNode
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
                saveValue.Value = context.transform.up;
            }
            else
            {
                saveValue.Value = transformValue.Value.up;
            }
            

            state = State.Success;
            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;

            description = "Retrieves the Up Direction of the object in World Space and saves the Up Direction in [SaveValue]";

            if (saveValue.reference == null)
            {
                description = "Unable to save value.";
            }
        }
    }
}