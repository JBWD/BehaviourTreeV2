using UnityEngine;
using UnityEngine.SceneManagement;

namespace Halcyon.BT
{
    
    [NodeMenuPath( "GameObject" )]
    [NodeTitle("GameObject:\nDestroy")]
    [NodeMenuName("GameObject: Destroy")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.none)]
    [CreateBBVariable("GameObject", BBVariableType.GameObject)]
    [CreateBBVariable("DelayInSeconds", BBVariableType.Number)]
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