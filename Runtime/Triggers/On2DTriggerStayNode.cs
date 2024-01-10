using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/2D", nodeTitle = "On 2D Trigger Stay", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class On2DTriggerStayNode : TriggerNode
    {
        public NodeProperty<string> collisionTag;
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
    }
}