using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Triggers/3D", nodeTitle = "On Collision Enter", nodeColor = NodeColors.purple,
        nodeIcon = NodeIcons.trigger)]
    public class OnCollisionEnterNode : TriggerNode
    {
        public NodeProperty<string> collisionTag;
        public NodeProperty<Collider> collider;


        public override void OnInit()
        {
            context.behaviourTreeInstance.On3DCollisionEnter += SaveCollisionAndRunNode;
        }
        public override void OnDisable()
        {
            context.behaviourTreeInstance.On3DCollisionEnter-= SaveCollisionAndRunNode;
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
            description = $"Activates when a trigger enters this GameObject's collider and has a tag of: " +
                          $"'{collisionTag.Value}' and will save the collider.";
        }

    }
}