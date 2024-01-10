﻿using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/3D", nodeTitle = "On Collision Stay", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnCollisionStayNode :TriggerNode
    {
        public NodeProperty<string> collisionTag;
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
            description = $"Activates when a trigger enters this GameObject's collider and has a tag of: " +
                          $"'{collisionTag.Value}' and will save the collider.";
        }

        public override void OnDrawGizmos()
        {
            Gizmos.DrawCube(context.gameObject.transform.position, new Vector3(1,1,1));
        }
    }
}