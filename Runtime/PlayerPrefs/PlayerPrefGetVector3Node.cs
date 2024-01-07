using System;
using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs/Get", menuName = "Player Prefs: Get Vector3", nodeTitle = "Player Prefs:\nGet Vector3", nodeIcon = NodeIcons.save,nodeColor = NodeColors.green)]
    [System.Serializable]
    public class PlayerPrefGetVector3Node : ActionNode
    {


        public NodeProperty<string> playerPrefName;

        public NodeProperty<Vector3> saveVector3Value;
        
        
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
                var z = UnityEngine.PlayerPrefs.GetFloat($"{playerPrefName}.z");

                saveVector3Value.Value = new Vector3(x, y, z);
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

            if (saveVector3Value.reference == null)
            {
                errored = true;
                description = "Unable to save value.";
            }
            else
            {
                errored = false;
                description =
                    "Tries to retrieve the Vector3 value from PlayerPrefs, if successful, saves the value in 'saveVector3Value'."; 
            }
            
        }
    }
}