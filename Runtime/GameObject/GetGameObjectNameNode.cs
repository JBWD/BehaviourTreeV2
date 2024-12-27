using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "GameObject/Get", menuName = "GameObject: Get Name", nodeColor = NodeColors.pink,
        nodeIcon = NodeIcons.none, nodeTitle = "GameObject:\nGet Name")]

    [System.Serializable]
    public class GetGameObjectNameNode: ActionNode
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
            
            if (context.gameObject != null)
            {
                nameValue.Value = context.gameObject.name;
                state = State.Success;
            }
           
            return state;
        }
        
        public override void UpdateDescription()
        {
            
            description = $"Retrieves the gameObjects name and saves it in [NameValue].";
        }
    }
}