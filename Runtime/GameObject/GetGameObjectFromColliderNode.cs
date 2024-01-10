using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Variable/Conversion", menuName = "Conversion: Collider to GameObject", nodeColor = NodeColors.pink,
        nodeIcon = NodeIcons.save, nodeTitle = "Conversion:\nCollider to GameObject")]
    [System.Serializable]
    public class GetGameObjectFromColliderNode : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<Collider> collider;
        [BlackboardValueOnly]
        public NodeProperty<GameObject> saveValue;
        
        
        protected override void OnStart()   
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (collider.Value != null)
            {
                saveValue.Value = collider.Value.gameObject;
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
            description = "Retrieves the GameObject that the collider is attached to.";
        }
    }
}