﻿using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs/Get", menuName = "Player Prefs: Delete All Keys", nodeTitle = "Player Prefs:\nDelete All Keys", nodeIcon = NodeIcons.save,nodeColor = NodeColors.green)]
    [System.Serializable]
    public class PlayerPrefDeleteAllKeysNode :ActionNode
    {
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;
            PlayerPrefs.DeleteAll();
            return state;
        }
    }
}