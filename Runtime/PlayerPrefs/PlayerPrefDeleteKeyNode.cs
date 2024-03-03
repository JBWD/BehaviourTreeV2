using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs", menuName = "Player Prefs: Delete Key", nodeTitle = "Player Prefs:\nDelete Key", nodeIcon = NodeIcons.save,nodeColor = NodeColors.pink)]
    [System.Serializable]
    public class PlayerPrefDeleteKeyNode : ActionNode
    {

        public NodeProperty<string> keyToDelete;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Success;
            PlayerPrefs.DeleteKey(keyToDelete.Value);
            return state;
        }
    }
    
}