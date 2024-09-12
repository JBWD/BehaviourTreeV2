using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode("Player Prefs", menuName = "Player Prefs: Delete All Keys", nodeTitle = "Player Prefs:\nDelete All Keys", nodeIcon = NodeIcons.save,nodeColor = NodeColors.pink)]
    [System.Serializable]
    public class PlayerPrefDeleteAllKeysNode :ActionNode
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
            PlayerPrefs.DeleteAll();
            return state;
        }
    }
}