using System;
using Unity.VisualScripting;
using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Triggers/3D", nodeTitle = "On Trigger Enter", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    [Serializable]
    public class OnTriggerEnterNode : TriggerNode
    {
        [Tooltip("This is a test")]
        public NodeProperty<string> collisionTag;
        public NodeProperty<Collider> collider;
        
        
        

        public override void OnInit()
        {
            if (collisionTag.Value == null)
            {
                collisionTag.Value = "";
            }
            context.behaviourTreeInstance.On3DTriggerEnter += SaveCollisionAndRunNode;
        }

        public override void OnDisable()
        {
            context.behaviourTreeInstance.On3DTriggerEnter -= SaveCollisionAndRunNode;
        }

        public void SaveCollisionAndRunNode(Collider collider)
        {
            if (collider.tag == collisionTag.Value)
            {
                this.collider.Value = collider;
                OnUpdate();
            }
            
        }
        

        public override void OnDrawGizmos()
        {
            Gizmos.DrawCube(context.gameObject.transform.position, new Vector3(1,1,1));
        }
        
        
    }
}