using UnityEngine;

namespace TheKiwiCoder.PlayerPrefs
{
    [BehaviourTreeNode("Player Prefs/Set", menuName = "Player Prefs: Set Vector3",nodeTitle = "Player Prefs:\nSet Vector3", nodeIcon = NodeIcons.save,nodeColor = NodeColors.green)]
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

          
               
                description =
                    "Saves the Vector3 value to PlayerPrefs."; 
            
            
        }
    }
}