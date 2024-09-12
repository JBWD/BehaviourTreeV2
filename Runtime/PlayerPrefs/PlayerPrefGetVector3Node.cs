using System;
using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode("Player Prefs/Get", menuName = "Player Prefs: Get Vector3", nodeTitle = "Player Prefs:\nGet Vector3", nodeIcon = NodeIcons.save,nodeColor = NodeColors.pink)]
    [System.Serializable]
    public class PlayerPrefGetVector3Node : ActionNode
    {


        public NodeProperty<string> playerPrefName;
        [BlackboardValueOnly]
        public NodeProperty<Vector3> saveValue;
        
        
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

                saveValue.Value = new Vector3(x, y, z);
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

            if (saveValue.reference == null)
            {
                errored = true;
                description = "Unable to save value.";
            }
            else
            {
                errored = false;
                description =
                    "Tries to retrieve the Vector3 value from PlayerPrefs, if successful, saves the value in 'saveValue'."; 
            }
            
        }
    }
}