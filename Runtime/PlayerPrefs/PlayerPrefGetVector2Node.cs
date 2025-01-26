using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Player Prefs:\n Get Vector2")]
    [NodeMenuName("Player Prefs: Get Vector2")]
    [NodeMenuPath("Player Prefs/Get")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("PlayerPrefName", BBVariableType.String)]
    [CreateBBVariable("SaveVector2Value", BBVariableType.Vector2)]
    [System.Serializable]
    public class PlayerPrefGetVector2Node : ActionNode
    {


        public NodeProperty<string> playerPrefName;
        [BlackboardValueOnly]
        public NodeProperty<Vector2> saveValue;
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        
        protected override State OnUpdate()
        {
            try
            {
                var x = UnityEngine.PlayerPrefs.GetFloat($"{playerPrefName}.x");
                var y = UnityEngine.PlayerPrefs.GetFloat($"{playerPrefName}.y");

                saveValue.Value = new Vector3(x, y);
                state = State.Success;
            }
            catch
            {
                state = State.Failure;
            }

            return state;

        }

        public override void UpdateDescription()
        {
            errored = false;
            if (saveValue.reference == null)
            {
                errored = true;
                description = "Unable to save value.";
            }
            else
            {
               
                description =
                    "Tries to retrieve the Vector2 value from PlayerPrefs, if successful, saves the value in 'saveValue'."; 
            }
            
        }
    }
}