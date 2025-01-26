using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Player Prefs:\n Save Keys")]
    [NodeMenuName("Player Prefs: Save Keys")]
    [NodeMenuPath("Player Prefs")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
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