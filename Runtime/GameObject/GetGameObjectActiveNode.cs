﻿using Unity.Properties;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath( "GameObject" )]
    [NodeTitle("GameObject:\nGet GameObject Active")]
    [NodeMenuName("GameObject: Get GameObject Active")] 
    [NodeIcon(NodeIcons.none)]
    [CreateBBVariable("GameObject", BBVariableType.GameObject)]
    [CreateBBVariable("ActivityState", BBVariableType.Boolean)]
    [System.Serializable]
    public class GetGameObjectActiveNode: ActionNode
    {
        public NodeProperty<GameObject> gameObject;
        [BlackboardValueOnly]
        public NodeProperty<bool> activityState;
        
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
                activityState.Value = gameObject.Value.activeInHierarchy;
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
            
            description = $"Retrieves the gameObjects LayerMask and saves it in [ActivityState].";
        }
    }
}