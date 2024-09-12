using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode("Player Prefs/Get", menuName = "Player Prefs: Get Integer", nodeTitle = "Player Prefs:\nGet Integer", nodeIcon = NodeIcons.save,nodeColor = NodeColors.pink)]
    [System.Serializable]

    public class PlayerPrefGetIntegerNode : ActionNode
    {
        
        public NodeProperty<string> playerPrefName;
        [BlackboardValueOnly] public NodeProperty<int> saveValue;
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;
            saveValue.Value = PlayerPrefs.GetInt(playerPrefName.Value, -1);
            
            
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
                    "Tries to retrieve the Integer value from PlayerPrefs, if successful, saves the value in 'saveValue'."; 
            }
            
        }
        
    }
}