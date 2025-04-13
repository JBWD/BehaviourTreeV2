using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Action")]
    [NodeTitle("Tower Defense:\nDecrease Life")]
    [NodeMenuName("Tower Defense: Decrease Life")] 
    [CreateBBVariable("LifeAmount", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseDecreaseLifeNode : ActionNode
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
