namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Trigger")]
    [NodeTitle("Tower Defense:\nOn Currency Increase")]
    [NodeMenuName("Tower Defense: On Currency Increase")] 
    [CreateBBVariable("SaveCurrencyIncrease", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseOnCurrencyIncreaseNode:TriggerNode
    {
        public NodeProperty<NumericProperty> SaveCurrencyIncrease = new NodeProperty<NumericProperty>();
        public override void OnInit()
        {
            TowerDefenseGameManager.Instance.OnCurrencyIncreaseAction += OnCurrencyIncrease;
        }

        private void OnCurrencyIncrease(int round)
        {
            SaveCurrencyIncrease.Value.IntegerValue = round;
            child.Update();
        }
    }
}