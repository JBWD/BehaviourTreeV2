using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Player Prefs:\n Get String")]
    [NodeMenuName("Player Prefs: Get String")]
    [NodeMenuPath("Player Prefs/Get")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("PlayerPrefName", BBVariableType.String)]
    [CreateBBVariable("SaveStringValue", BBVariableType.String)]
    
    [System.Serializable]

    public class PlayerPrefGetStringNode : ActionNode
    
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
            saveValue.Value = PlayerPrefs.GetString(playerPrefName.Value, "");
            
            if (saveValue.Value == "")
                state = State.Failure;

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
                    "Tries to retrieve the String value from PlayerPrefs, if successful, saves the value in 'saveValue'."; 
            }
            
        }
    }
}