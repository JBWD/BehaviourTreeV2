using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Physics")]
    [NodeTitle("On Trigger Exit")]
    [NodeMenuName("Physics: On Trigger Exit")] 
    [CreateBBVariable("SaveCollider", BBVariableType.Collider)]
    [CreateBBVariable("SaveGameObject", BBVariableType.GameObject)]
    [CreateBBVariable("SaveTransform", BBVariableType.Transform)]
    [System.Serializable]
    public class OnTriggerExitNode: TriggerNode
    {
        public LayerMask collisionLayer = -1;
        [Tooltip("Tag of the object that you wish to have collisions with.")]
        public NodeProperty<string> collisionTag;
        [Space,BlackboardValueOnly, Tooltip("Blackboard value you wish to have the Collider saved in.")]
        public NodeProperty<Collider> saveCollider;
        [BlackboardValueOnly, Tooltip("Blackboard value you wish to have the Collider's Transform saved in.")]
        public NodeProperty<Transform> saveTransform;
        [BlackboardValueOnly, Tooltip("Blackboard value you wish to have the Collider's GameObject saved in.")]
        public NodeProperty<GameObject> saveGameObject;


        public override void OnInit()
        {
            context.BehaviourTreeRunner.On3DTriggerExit += SaveCollisionAndRunNode;
        }
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.On3DTriggerExit -= SaveCollisionAndRunNode;
        }
        public virtual void SaveCollisionAndRunNode(Collider collider)
        {
            if (!collisionLayer.Contains(collider.gameObject.layer))
                return;
            
            if (collider.tag == collisionTag.Value || collisionTag.Value.Trim() == "")
            {
                this.saveCollider.Value = collider;
                this.saveTransform.Value = collider.transform;
                this.saveGameObject.Value = collider.transform.gameObject;
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