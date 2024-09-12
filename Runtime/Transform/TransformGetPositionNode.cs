using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Transform/Get", menuName = "Transform: Get Position", nodeTitle = "Transform:\nGet Position",
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
    [System.Serializable]
    public class TransformGetPositionNode : ActionNode
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
                saveValue.Value = context.transform.position;
            }
            else
            {
                saveValue.Value = transformValue.Value.position;
            }
            

            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;

            description = "Retrieves the position of the object in World Space and saves the position in [SaveValue]";

            if (saveValue.reference == null)
            {
                description = "Unable to save value.";
            }
        }
    }
}