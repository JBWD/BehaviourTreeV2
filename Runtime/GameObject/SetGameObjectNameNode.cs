using UnityEngine;
using UnityEngine.Serialization;

namespace Halcyon.BT
{
    [NodeMenuPath( "GameObject/Set" )]
    [NodeTitle("GameObject:\nSet GameObject Name")]
    [NodeMenuName("GameObject: Set GameObject Name")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.save)]
    [CreateBBVariable("GameObject", BBVariableType.GameObject)]
    [CreateBBVariable("NameValue", BBVariableType.String)]
    [System.Serializable]
    public class SetGameObjectNameNode : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<GameObject> gameObject;
        public bool self = true;
        public NodeProperty<string> nameValue;
        
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
                    nameValue.Value = gameObject.Value.name;
                    state = State.Success;
                }
            }
            
            if (state == State.Success)
                return state;

            if (gameObject.Value != null)
            {
                gameObject.Value.name = nameValue.Value;
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
            
            description = $"Sets the 'GameObject's active state to '{nameValue.Value}'.";
        }
    }
}