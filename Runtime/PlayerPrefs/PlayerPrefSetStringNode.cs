using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode("Player Prefs/Set", menuName = "Player Prefs: Set String", nodeTitle = "Player Prefs:\nSet String", nodeIcon = NodeIcons.save,nodeColor = NodeColors.pink)]
    [System.Serializable]
    public class PlayerPrefSetStringNode : ActionNode
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

            PlayerPrefs.SetString(playerPrefName.Value, saveValue.Value);
            
            return state;
        }
        public override void UpdateDescription()
        {
            description = "Saves the value value to PlayerPrefs.";
        }
    }
}