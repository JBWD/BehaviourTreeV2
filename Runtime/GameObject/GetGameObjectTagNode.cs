using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath( "GameObject/Get" )]
    [NodeTitle("GameObject:\nGet GameObject Tag")]
    [NodeMenuName("GameObject: Get GameObject Tag")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.save)]
    [CreateBBVariable("GameObject", BBVariableType.GameObject)]
    [CreateBBVariable("TagValue", BBVariableType.String)]
    [System.Serializable]
    public class GetGameObjectTagNode :ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<GameObject> gameObject;
        public bool self = true;
        [BlackboardValueOnly]
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
            
            
            if (context.gameObject != null)
            {
                tagValue.Value = context.gameObject.tag;
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
            
            description = $"Retrieves the gameObjects tag and saves it in [TagValue].";
        }
    }
}