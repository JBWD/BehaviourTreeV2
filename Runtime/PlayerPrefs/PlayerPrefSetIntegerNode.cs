using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs/Set", menuName = "Player Prefs: Set Integer", nodeTitle = "Player Prefs:\nSet Integer", nodeIcon = NodeIcons.save,nodeColor = NodeColors.pink)]
    [System.Serializable]
    public class PlayerPrefSetIntegerNode : ActionNode
    {
        public NodeProperty<string> playerPrefName;
        public NodeProperty<int> saveValue;
        
       
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;


            PlayerPrefs.SetInt(playerPrefName.Value, saveValue.Value);
            
            return state;
        }
        
        public override void UpdateDescription()
        {
            description = "Saves the value value to PlayerPrefs.";
        }
    }
}