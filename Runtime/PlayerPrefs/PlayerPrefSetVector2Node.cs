using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs/Set", menuName = "Player Prefs: Set Vector2",nodeTitle = "Player Prefs:\nSet Vector2", nodeIcon = NodeIcons.save,nodeColor = NodeColors.green)]
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