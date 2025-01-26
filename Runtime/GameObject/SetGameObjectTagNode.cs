using UnityEngine;
using UnityEngine.Serialization;

namespace Halcyon.BT
{
    [NodeMenuPath( "GameObject/Set" )]
    [NodeTitle("GameObject:\nSet GameObject Tag")]
    [NodeMenuName("GameObject: Set GameObject Tag")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.save)]
    [CreateBBVariable("GameObject", BBVariableType.GameObject)]
    [CreateBBVariable("TagValue", BBVariableType.String)]
    [System.Serializable]
    public class SetGameObjectTagNode : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<GameObject> gameObject;
        public bool self = true;
         public NodeProperty<string> tagValue;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            state = State.Failure;
            if(!self)
            {
                if(gameObject != null)
                {
                    tagValue.Value = gameObject.Value.tag;
                    state = State.Success;
                }
            }
            
            if (state == State.Success)
                return state;

            if (gameObject.Value != null)
            {
                gameObject.Value.tag = tagValue.Value;
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
            
            description = $"Sets the 'GameObject's active state to '{tagValue.Value}'.";
        }
    }
}