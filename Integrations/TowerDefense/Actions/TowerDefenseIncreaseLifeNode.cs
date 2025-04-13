using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Action")]
    [NodeTitle("Tower Defense:\nIncrease Life")]
    [NodeMenuName("Tower Defense: Increase Life")] 
    [CreateBBVariable("LifeAmount", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseIncreaseLifeNode : ActionNode
    {
        public NodeProperty<NumericProperty> lifeAmount;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            TowerDefenseGameManager.Instance.IncreaseLives(lifeAmount.Value.IntegerValue);
            return State.Success;
        }
    }
}
