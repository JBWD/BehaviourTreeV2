using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Action")]
    [NodeTitle("Tower Defense:\nIncrease Round")]
    [NodeMenuName("Tower Defense: Increase Round")] 
    [System.Serializable]
    public class TowerDefenseIncreaseRoundNode : ActionNode
    {
       

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            TowerDefenseGameManager.Instance.IncrementRound();
            return State.Success;
        }
    }
}
