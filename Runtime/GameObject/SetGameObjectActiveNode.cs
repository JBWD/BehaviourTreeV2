using UnityEngine;

namespace TheKiwiCoder
{
    
    [BehaviourTreeNode(menuPath = "GameObject", nodeColor = NodeColors.pink,nodeIcon = NodeIcons.none, nodeTitle = "Set Active")]
    public class SetGameObjectActiveNode : ActionNode
    {
        public NodeProperty<GameObject> gameObject;
        public NodeProperty<bool> activityState;
        
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
                gameObject.Value.SetActive(activityState.Value);
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