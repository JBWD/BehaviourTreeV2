using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuFolder = "GameObject", nodeColor = NodeColors.pink,nodeIcon = NodeIcons.none, nodeTitle = "Set Tag")]
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
    }
}