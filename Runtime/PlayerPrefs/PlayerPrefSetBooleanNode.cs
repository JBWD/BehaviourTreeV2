using Unity.VisualScripting;
using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs/Set", menuName = "Player Prefs: Set Boolean", nodeTitle = "Player Prefs:\nSet Boolean", nodeIcon = NodeIcons.save,nodeColor = NodeColors.green)]
    [System.Serializable]
    public class PlayerPrefSetBooleanNode : ActionNode
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
            int value = 0;
            if (saveValue.Value)
                value = 1;
           
            
            PlayerPrefs.SetInt(playerPrefName.Value, value);
            
            return state;
        }
        
        public override void UpdateDescription()
        {
            description = "Saves the value value to PlayerPrefs.";
        }
    }
}