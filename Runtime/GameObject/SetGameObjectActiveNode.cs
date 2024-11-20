using UnityEngine;

namespace Halcyon.BT
{

    [NodeColor(NodeColors.pink)]
    [NodeTitle("GameObject:\nSet Active")]
    [NodeMenuPath("GameObject/Set")]
    [NodeMenuName("GameObject: Set Active")]
    [System.Serializable]
    public class SetGameObjectActiveNode : ActionNode
    {
        public NodeProperty<GameObject> gameObject;
        public bool self = true;
        public NodeProperty<bool> activityState;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (self)
            {
                context.gameObject.SetActive(activityState.Value);
                state = State.Success;
            }
            else if (gameObject.Value != null)
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

        public override void UpdateDescription()
        {
            
            description = $"Sets the 'GameObject's active state to '{activityState.Value}'.";
        }
    }
}