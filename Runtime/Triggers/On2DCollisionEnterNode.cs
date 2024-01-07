using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers/2D", nodeTitle = "On 2D Collision Enter", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class On2DCollisionEnterNode : TriggerNode
    {
        public NodeProperty<string> collisionTag;
        public NodeProperty<Collider2D> collider;
        

        public override void OnInit()
        {
            context.BehaviourTreeRunner.On2DCollisionEnter+= SaveCollisionAndRunNode;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.On2DCollisionEnter-= SaveCollisionAndRunNode;
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