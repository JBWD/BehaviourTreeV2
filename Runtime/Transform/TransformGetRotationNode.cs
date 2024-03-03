using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Transform/Get", menuName = "Transform: Get Rotation", nodeTitle = "Transform:\n Get Rotation",
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
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