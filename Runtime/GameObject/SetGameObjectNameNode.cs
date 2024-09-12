﻿using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "GameObject/Set", menuName = "GameObject: Set Name", nodeColor = NodeColors.pink,
        nodeIcon = NodeIcons.none, nodeTitle = "GameObject:\nSet Name")]
    [System.Serializable]
    public class SetGameObjectNameNode : ActionNode
    {
        public NodeProperty<GameObject> gameObject;
        public NodeProperty<string> name;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (gameObject.Value != null)
            {
                gameObject.Value.name = name.Value;
                state = State.Success;
            }
            else
            {
                state = State.Failure;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            
            description = $"Sets the 'GameObject's active state to '{name.Value}'.";
        }
    }
}