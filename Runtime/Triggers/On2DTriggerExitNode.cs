﻿using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers/2D", nodeTitle = "On 2D Trigger Exit", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class On2DTriggerExitNode : TriggerNode
    {
        public NodeProperty<string> collisionTag;
        public NodeProperty<Collider2D> collider;
        

        public override void OnInit()
        {
            context.BehaviourTreeRunner.On2DTriggerExit += SaveCollisionAndRunNode;
        }
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.On2DTriggerExit -= SaveCollisionAndRunNode;
        }
        public void SaveCollisionAndRunNode(Collider2D collider)
        {
            if (collider.CompareTag(collisionTag.Value))
            {
                this.collider.Value = collider;
                OnUpdate();
            }
            
        }

        public override void UpdateDescription()
        {
            
        }
        

    }
}