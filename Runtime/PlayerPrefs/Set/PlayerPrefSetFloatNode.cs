using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Player Prefs:\n Set Float")]
    [NodeMenuName("Player Prefs: Set Float")]
    [NodeMenuPath("Player Prefs/Set")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("PlayerPrefName", BBVariableType.String)]
    [CreateBBVariable("NumericValue", BBVariableType.Number)]
    [System.Serializable]
    public class PlayerPrefSetFloatNode : ActionNode
    {
        public NodeProperty<string> playerPrefName;
        [BlackboardValueOnly] public NodeProperty<NumericProperty> saveValue;
        
       
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;


            PlayerPrefs.SetFloat(playerPrefName.Value, saveValue.Value.FloatValue);
            
            return state;
        }
        
        public override void UpdateDescription()
        {
            description = "Saves the value value to PlayerPrefs.";
        }
    }
}