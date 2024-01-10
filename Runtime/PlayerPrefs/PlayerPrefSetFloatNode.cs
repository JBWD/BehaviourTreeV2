using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs/Set", menuName = "Player Prefs: Set Float", nodeTitle = "Player Prefs:\nSet Float", nodeIcon = NodeIcons.save,nodeColor = NodeColors.green)]
    [System.Serializable]
    public class PlayerPrefSetFloatNode : ActionNode
    {
        public NodeProperty<string> playerPrefName;
        [BlackboardValueOnly] public NodeProperty<float> saveValue;
        
       
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;


            PlayerPrefs.SetFloat(playerPrefName.Value, saveValue.Value);
            
            return state;
        }
        
        public override void UpdateDescription()
        {
            description = "Saves the value value to PlayerPrefs.";
        }
    }
}