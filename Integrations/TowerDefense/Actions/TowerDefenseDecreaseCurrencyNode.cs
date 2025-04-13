using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    
    [NodeMenuPath("Integrations/Tower Defense/Action")]
    [NodeTitle("Tower Defense:\nDecrease Currency")]
    [NodeMenuName("Tower Defense: Decrease Currency")] 
    [CreateBBVariable("CurrencyAmount", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseDecreaseCurrencyNode : ActionNode
    {
        public NodeProperty<NumericProperty> currencyAmount;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            TowerDefenseGameManager.Instance.DecreaseCurrency(currencyAmount.Value.IntegerValue);
            return State.Success;
        }
    }
}
