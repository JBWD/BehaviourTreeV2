using Unity.VisualScripting;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Player Prefs/Set")]
    [NodeMenuName("Player Prefs: Set Boolean")]
    [NodeTitle("Player Prefs:\nSet Boolean")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
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