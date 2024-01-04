using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Triggers/2D", nodeTitle = "On 2D Trigger Enter", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class On2DTriggerEnterNode : TriggerNode
    {
        public NodeProperty<string> collisionTag;
        public NodeProperty<Collider2D> collider;
        

        public override void OnInit()
        {
            context.behaviourTreeInstance.On2DTriggerEnter += SaveCollisionAndRunNode;
        }
        public override void OnDisable()
        {
            context.behaviourTreeInstance.On2DTriggerEnter-= SaveCollisionAndRunNode;
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