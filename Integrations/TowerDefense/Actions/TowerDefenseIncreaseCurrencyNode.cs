using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Action")]
    [NodeTitle("Tower Defense:\nIncrease Currency")]
    [NodeMenuName("Tower Defense: Increase Currency")] 
    [CreateBBVariable("CurrencyAmount", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseIncreaseCurrencyNode :ActionNode
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
            TowerDefenseGameManager.Instance.IncreaseCurrency(currencyAmount.Value.IntegerValue);
            return State.Success;
        }
    }
}
