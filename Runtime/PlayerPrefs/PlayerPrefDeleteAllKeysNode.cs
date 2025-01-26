using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Player Prefs:\n Delete All Keys")]
    [NodeMenuName("Player Prefs: Delete All Keys")]
    [NodeMenuPath("Player Prefs")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
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