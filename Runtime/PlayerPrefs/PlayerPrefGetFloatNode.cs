using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs/Get", menuName = "Player Prefs: Get Float", nodeTitle = "Player Prefs:\nGet Float", nodeIcon = NodeIcons.save,nodeColor = NodeColors.pink)]
    [System.Serializable]
    public class PlayerPrefGetFloatNode : ActionNode
    {
        public NodeProperty<string> playerPrefName;
        [BlackboardValueOnly] public NodeProperty<float> saveValue;




        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;
            saveValue.Value = PlayerPrefs.GetFloat(playerPrefName.Value, -1);
            
            
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
                    "Tries to retrieve the Float value from PlayerPrefs, if successful, saves the value in 'saveValue'."; 
            }
            
        }
    }
}