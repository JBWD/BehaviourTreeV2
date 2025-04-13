using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Action")]
    [NodeTitle("Tower Defense:\nGet Currency")]
    [NodeMenuName("Tower Defense: Get Currency")] 
    [CreateBBVariable("SaveCurrencyAmount", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseGetCurrencyNode : ActionNode
    {
       
        public NodeProperty<NumericProperty> SaveCurrency;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {

            if (SaveCurrency != null)
            {
                SaveCurrency.Value.IntegerValue = TowerDefenseGameManager.Instance.GetCurrentCurrency();
                return State.Success;
            }
             
            return State.Failure;
        }
    }
}
