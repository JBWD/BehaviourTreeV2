using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Player Prefs:\n Set Vector3")]
    [NodeMenuName("Player Prefs: Set Vector3")]
    [NodeMenuPath("Player Prefs/Set")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("PlayerPrefName", BBVariableType.String)]
    [CreateBBVariable("Vector3Value", BBVariableType.Vector3)]
    [System.Serializable]
    public class PlayerPrefSetVector3Node : ActionNode
    {


        public NodeProperty<string> playerPrefName;

        public NodeProperty<Vector3> vector3Value;
        
        
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
                UnityEngine.PlayerPrefs.SetFloat($"{playerPrefName}.x", vector3Value.Value.x );
                UnityEngine.PlayerPrefs.SetFloat($"{playerPrefName}.y", vector3Value.Value.y);
                UnityEngine.PlayerPrefs.SetFloat($"{playerPrefName}.z", vector3Value.Value.z);
                
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