using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "GameObject", nodeColor = NodeColors.pink,nodeIcon = NodeIcons.none, nodeTitle = "Set Name")]
    [System.Serializable]
    public class SetGameObjectNameNode : ActionNode
    {
        public NodeProperty<GameObject> gameObject;
        public NodeProperty<string> name;
        
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
                gameObject.Value.name = name.Value;
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