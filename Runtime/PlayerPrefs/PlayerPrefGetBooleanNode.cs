﻿using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs/Get", menuName = "Player Prefs: Get Boolean", nodeTitle = "Player Prefs:\nGet Boolean", nodeIcon = NodeIcons.save,nodeColor = NodeColors.green)]
    [System.Serializable]

    public class PlayerPrefGetBooleanNode : ActionNode
    {
        public NodeProperty<string> playerPrefName;
        [BlackboardValueOnly] public NodeProperty<bool> saveValue;
        
       
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;
            var value =  PlayerPrefs.GetInt(playerPrefName.Value, 2);

            switch (value)
            {
                case 0:
                    saveValue.Value = false;
                    break;
                case 1:
                    saveValue.Value = true;
                    break;
                default:
                    saveValue.Value = false;
                    state = State.Failure;
                    break;
            }
            
            return state;
        }
        
        public override void UpdateDescription()
        {

            if (saveValue.reference == null)
            {
                errored = true;
                description = "Unable to save value.";
            }
            else
            {
                errored = false;
                description =
                    "Tries to retrieve the Boolean value from PlayerPrefs, if successful, saves the value in 'saveValue'."; 
            }
            
        }
        
    }
}