using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/3D", nodeTitle = "On Collision Stay", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public class OnCollisionStayNode :TriggerNode
    {
        public NodeProperty<string> collisionTag;
        [BlackboardValueOnly]
        public NodeProperty<Collider> collider;
        

        public override void OnInit()
        {
            context.BehaviourTreeRunner.On3DCollisionStay += SaveCollisionAndRunNode;
        }
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.On3DCollisionStay-= SaveCollisionAndRunNode;
        }
        public void SaveCollisionAndRunNode(Collision collision)
        {
            if (collision.collider.CompareTag(collisionTag.Value))
            {
                this.collider.Value = collision.collider;
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