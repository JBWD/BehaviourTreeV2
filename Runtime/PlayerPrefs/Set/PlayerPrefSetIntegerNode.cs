using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Player Prefs:\n Set Integer")]
    [NodeMenuName("Player Prefs: Set Integer")]
    [NodeMenuPath("Player Prefs/Set")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("PlayerPrefName", BBVariableType.String)]
    [CreateBBVariable("NumericValue", BBVariableType.Number)]
    [System.Serializable]
    public class PlayerPrefSetIntegerNode : ActionNode
    {
        public NodeProperty<string> playerPrefName;
        public NodeProperty<NumericProperty> saveValue;
        
       
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;


            PlayerPrefs.SetInt(playerPrefName.Value, saveValue.Value.IntegerValue);
            
            return state;
        }
        
        public override void UpdateDescription()
        {
            description = "Saves the value value to PlayerPrefs.";
        }
    }
}