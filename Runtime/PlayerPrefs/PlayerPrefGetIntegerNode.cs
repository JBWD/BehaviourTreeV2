using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Player Prefs:\n Get Integer")]
    [NodeMenuName("Player Prefs: Get Integer")]
    [NodeMenuPath("Player Prefs/Get")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("PlayerPrefName", BBVariableType.String)]
    [CreateBBVariable("SaveNumericValue", BBVariableType.Number)]
    [System.Serializable]

    public class PlayerPrefGetIntegerNode : ActionNode
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
            saveValue.Value.IntegerValue = PlayerPrefs.GetInt(playerPrefName.Value, -1);
            
            
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