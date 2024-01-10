using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Player Prefs/Get", menuName = "Player Prefs: Delete Keys", nodeTitle = "Player Prefs:\nDelete Keys", nodeIcon = NodeIcons.save,nodeColor = NodeColors.green)]
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