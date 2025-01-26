using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath( "GameObject/Conversion" )]
    [NodeTitle("GameObject:\nGet GameObject\nfrom Collider")]
    [NodeMenuName("GameObject: Get GameObject from Collider")] 
    [NodeIcon(NodeIcons.none)]
    [CreateBBVariable("Collider", BBVariableType.Collider)]
    [CreateBBVariable("SaveObject", BBVariableType.GameObject)]
    [System.Serializable]
    public class GetGameObjectFromColliderNode : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<Collider> collider;
        [BlackboardValueOnly]
        public NodeProperty<GameObject> saveValue;
        
        
        protected override void OnStart()   
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (collider.Value != null)
            {
                saveValue.Value = collider.Value.gameObject;
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
            errored = false;
            
            if (saveValue.reference != null && collider.Value != null)
            {

                description =
                    $"Saves the GameObject of 'TransformValue' in '{saveValue.reference.name}'.";
            }
            else
            {
                description = "Does not save the value";
                errored = true;
            }
            
        } 
    }
}