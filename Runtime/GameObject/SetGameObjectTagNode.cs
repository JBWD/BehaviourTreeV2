using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "GameObject/Set", menuName = "GameObject: Set Tag", nodeColor = NodeColors.pink,nodeIcon = NodeIcons.none, nodeTitle = "GameObject:\nSet Tag")]
    [System.Serializable]
    public class SetGameObjectTagNode : ActionNode
    {
        public NodeProperty<GameObject> gameObject;
        public NodeProperty<TagKey> tag;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (gameObject.Value != null)
            {
                gameObject.Value.tag = tag.Value.value;
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
            
            description = $"Sets the 'GameObject's active state to '{tag.Value}'.";
        }
    }
}