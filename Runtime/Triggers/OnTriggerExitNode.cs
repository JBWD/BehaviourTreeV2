using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/3D", nodeTitle = "On Trigger Exit", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnTriggerExitNode: TriggerNode
    {
        public NodeProperty<string> collisionTag;
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
            description = $"Activates when a trigger enters this GameObject's collider and has a tag of: " +
                          $"'{collisionTag.Value}' and will save the collider.";
        }

        public override void OnDrawGizmos()
        {
            Gizmos.DrawCube(context.gameObject.transform.position, new Vector3(1,1,1));
        }
    }
}