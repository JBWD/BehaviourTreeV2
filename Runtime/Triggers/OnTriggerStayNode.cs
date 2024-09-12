using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/3D", nodeTitle = "On Trigger Stay", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    [System.Serializable]
    public class OnTriggerStayNode : TriggerNode
    {
        public NodeProperty<string> collisionTag;
        [BlackboardValueOnly]
        public NodeProperty<Collider> collider;
        

        public override void OnInit()
        {
            context.BehaviourTreeRunner.On3DTriggerStay += SaveCollisionAndRunNode;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.On3DTriggerStay -= SaveCollisionAndRunNode;
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