using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Physics")]
    [NodeTitle("On Trigger Enter")]
    [NodeMenuName("Physics: On Trigger Enter")]
    [CreateBBVariable("SaveCollider", BBVariableType.Collider)]
    [CreateBBVariable("SaveGameObject", BBVariableType.GameObject)]
    [CreateBBVariable("SaveTransform", BBVariableType.Transform)]
    [Serializable]
    public class OnTriggerEnterNode : TriggerNode
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
            if (collisionTag.Value == null)
            {
                collisionTag.Value = "";
            }
            context.BehaviourTreeRunner.On3DTriggerEnter += SaveCollisionAndRunNode;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.On3DTriggerEnter -= SaveCollisionAndRunNode;
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
                "When a collision occurs, all children nodes are invoked, this does not repeat like the main loop.\n\n" +
                "Note: Not all saves need to be used.";
        }
        
    }
}