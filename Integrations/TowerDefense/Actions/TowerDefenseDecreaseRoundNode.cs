using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Action")]
    [NodeTitle("Tower Defense:\nDecrease Round")]
    [NodeMenuName("Tower Defense: Decrease Round")] 
    [System.Serializable]
    public class TowerDefenseDecreaseRoundNode : ActionNode
    {
       

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            TowerDefenseGameManager.Instance.DecreaseRound();
            return State.Success;
        }
    }
}
