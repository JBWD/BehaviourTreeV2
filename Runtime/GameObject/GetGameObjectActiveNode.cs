using Unity.Properties;
using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "GameObject", nodeColor = NodeColors.pink,nodeIcon = NodeIcons.none, nodeTitle = "Get Active")]
    [System.Serializable]
    public class GetGameObjectActiveNode: ActionNode
    {
        public NodeProperty<GameObject> gameObject;
        [BlackboardValueOnly]
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
                activityState.Value = gameObject.Value.activeInHierarchy;
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