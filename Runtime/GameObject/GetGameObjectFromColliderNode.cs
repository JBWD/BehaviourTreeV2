using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "GameObject", nodeColor = NodeColors.pink,nodeIcon = NodeIcons.none, nodeTitle = "Save GameObject From Collider")]
    public class GetGameObjectFromColliderNode : ActionNode
    {
        public NodeProperty<Collider> retrieveFrom;
        public NodeProperty<GameObject> saveTo;
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (retrieveFrom.Value != null)
            {
                saveTo.Value = retrieveFrom.Value.gameObject;
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