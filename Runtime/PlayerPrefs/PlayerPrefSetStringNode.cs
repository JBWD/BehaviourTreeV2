using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Player Prefs:\n Set Float")]
    [NodeMenuName("Player Prefs: Set Float")]
    [NodeMenuPath("Player Prefs/Set")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("PlayerPrefName", BBVariableType.String)]
    [CreateBBVariable("StringValue", BBVariableType.String)]
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