using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs/Get", menuName = "Player Prefs: Get String", nodeTitle = "Player Prefs:\nGet String", nodeIcon = NodeIcons.save,nodeColor = NodeColors.green)]
    [System.Serializable]

    public class PlayerPrefGetStringNode : ActionNode
    
    {
        public NodeProperty<string> playerPrefName;
        [BlackboardValueOnly] public NodeProperty<string> saveValue;
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;
            saveValue.Value = PlayerPrefs.GetString(playerPrefName.Value, "");
            
            if (saveValue.Value == "")
                state = State.Failure;

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
                    "Tries to retrieve the String value from PlayerPrefs, if successful, saves the value in 'saveValue'."; 
            }
            
        }
    }
}