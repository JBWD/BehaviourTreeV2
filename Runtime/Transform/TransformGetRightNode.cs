using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Transform/Get", menuName = "Transform: Get Right", nodeTitle = "Transform:\nGet Right",
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
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