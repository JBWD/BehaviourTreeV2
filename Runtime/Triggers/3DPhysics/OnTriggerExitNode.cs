using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Physics")]
    [NodeTitle("On Trigger Exit")]
    [NodeMenuName("Physics: On Trigger Exit")] 
    [System.Serializable]
    public class OnTriggerExitNode: TriggerNode
    {
        public NodeProperty<string> collisionTag;
        [BlackboardValueOnly]
        public NodeProperty<Collider> collider;
        

        public override void OnInit()
        {
            context.BehaviourTreeRunner.On3DTriggerExit += SaveCollisionAndRunNode;
        }
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.On3DTriggerExit -= SaveCollisionAndRunNode;
        }
        public void SaveCollisionAndRunNode(Collider collider)
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