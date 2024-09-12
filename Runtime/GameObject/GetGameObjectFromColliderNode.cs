using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Variable/Conversion", menuName = "Conversion: Collider to GameObject", nodeColor = NodeColors.pink,
        nodeIcon = NodeIcons.repeat, nodeTitle = "Conversion:\nCollider to GameObject")]
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
            errored = false;
            
            if (saveValue.reference != null && collider.Value != null)
            {

                description =
                    $"Saves the GameObject of 'TransformValue' in '{saveValue.reference.name}'.";
            }
            else
            {
                description = "Does not save the value";
                errored = true;
            }
            
        } 
    }
}