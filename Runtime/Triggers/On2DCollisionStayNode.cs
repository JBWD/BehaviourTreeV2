using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuFolder = "Triggers", nodeTitle = "On 2D Collision Stay", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class On2DCollisionStayNode : TriggerNode
    {
        public NodeProperty<string> collisionTag;
        public NodeProperty<Collider2D> collider;
        

        public override void OnInit()
        {
            context.behaviourTreeInstance.On2DCollisionStay += SaveCollisionAndRunNode;
        }
        public override void OnDisable()
        {
            context.behaviourTreeInstance.On2DCollisionStay-= SaveCollisionAndRunNode;
        }
        public void SaveCollisionAndRunNode(Collision2D collision)
        {
            if (collision.collider.CompareTag(collisionTag.Value))
            {
                this.collider.Value = collision.collider;
                OnUpdate();
            }
            
        }
    }
}