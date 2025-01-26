using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("Player Prefs:\n Delete Key")]
    [NodeMenuName("Player Prefs: Delete Key")]
    [NodeMenuPath("Player Prefs")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("KeyToDelete", BBVariableType.String)]
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