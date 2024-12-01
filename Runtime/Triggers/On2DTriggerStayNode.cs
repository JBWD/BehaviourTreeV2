using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Physics")]
    [NodeTitle("On 2D Trigger Stay")]
    [NodeMenuName("Physics: On 2D Trigger Stay")]
    [System.Serializable]
    public class On2DTriggerStayNode : TriggerNode
    {
        public NodeProperty<string> collisionTag;
        [BlackboardValueOnly]
        public NodeProperty<Collider2D> collider;
        

        public override void OnInit()
        {
            context.BehaviourTreeRunner.On2DTriggerStay += SaveCollisionAndRunNode;
        }
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.On2DTriggerStay-= SaveCollisionAndRunNode;
        }
        public void SaveCollisionAndRunNode(Collider2D collider)
        {
            if (collider.CompareTag(collisionTag.Value))
            {
                this.collider.Value = collider;
                OnUpdate();
            }
            
        }
        
        public override void UpdateDescription()
        {
            description =
                "When a collision occurs, all children nodes are invoked, this does not repeat like the main loop.";
        }
    }
}