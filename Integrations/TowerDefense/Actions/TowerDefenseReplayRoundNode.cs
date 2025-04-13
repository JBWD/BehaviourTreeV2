using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Action")]
    [NodeTitle("Tower Defense:\nReplay Round")]
    [NodeMenuName("Tower Defense: Replay Round")] 
    [System.Serializable]
    public class TowerDefenseReplayRoundNode : ActionNode
    {
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
            TowerDefenseGameManager.Instance.ReplayRound();
            return State.Success;
        }
    }
}
