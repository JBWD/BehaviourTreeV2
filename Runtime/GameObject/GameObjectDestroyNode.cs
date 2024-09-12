using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "GameObject/Get", menuName = "GameObject: Destroy", nodeColor = NodeColors.pink,nodeIcon = NodeIcons.none, nodeTitle = "GameObject:\nDestroy")]
    [System.Serializable]
    public class GameObjectDestroyNode: ActionNode
    {
        public NodeProperty<GameObject> gameObject;
        public bool self = true;
        public NodeProperty<float> delayTimeInSeconds;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (self || gameObject.Value == null)
            {
                MonoBehaviour.Destroy(context.gameObject, delayTimeInSeconds.Value);
                state = State.Success;
            }
            else if(!self)
            {
                MonoBehaviour.Destroy(gameObject.Value, delayTimeInSeconds.Value);
            }
            else
            {
                state = State.Failure;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            
            description = $"Destroys the desired gameObject after {delayTimeInSeconds.Value} seconds.";
        }
    }
}