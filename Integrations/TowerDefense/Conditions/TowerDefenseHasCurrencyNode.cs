using UnityEditor.Build.Content;
using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Condition")]
    [NodeTitle("Tower Defense:\nHas Currency")]
    [NodeMenuName("Tower Defense: Has Currency")] 
    [CreateBBVariable("CurrencyAmount", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseHasCurrencyNode : ComparisonNode
    {
        public NodeProperty<NumericProperty> currencyAmount;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        public override bool CheckComparison()
        {
            return currencyAmount.Value.IntegerValue > TowerDefenseGameManager.Instance.GetCurrentCurrency();
        }
    }
}