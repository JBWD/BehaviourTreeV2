using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs", menuName = "Player Prefs: Save", nodeTitle = "Player Prefs:\nSave", nodeIcon = NodeIcons.save,nodeColor = NodeColors.pink)]
    [System.Serializable]

    public class PlayerPrefSaveNode : ActionNode
    {
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;
            PlayerPrefs.Save();
            return state;
        }
    }
}