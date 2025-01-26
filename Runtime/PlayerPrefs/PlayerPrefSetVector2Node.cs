using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Player Prefs:\n Set Vector2")]
    [NodeMenuName("Player Prefs: Set Vector2")]
    [NodeMenuPath("Player Prefs/Set")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("PlayerPrefName", BBVariableType.String)]
    [CreateBBVariable("Vector2Value", BBVariableType.Vector2)]
    [System.Serializable]
    public class PlayerPrefSetVector2Node : ActionNode
    {


        public NodeProperty<string> playerPrefName;
        public NodeProperty<Vector2> vector2Value;
        
        
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
                UnityEngine.PlayerPrefs.SetFloat($"{playerPrefName}.x", vector2Value.Value.x );
                UnityEngine.PlayerPrefs.SetFloat($"{playerPrefName}.y", vector2Value.Value.y);

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
            description = "Saves the value value to PlayerPrefs.";
        }
    }
}