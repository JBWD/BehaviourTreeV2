namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Trigger")]
    [NodeTitle("Tower Defense:\nOn Currency Decrease")]
    [NodeMenuName("Tower Defense: On Currency Decrease")] 
    [CreateBBVariable("SaveCurrencyDecrease", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseOnCurrencyDecreaseNode: TriggerNode
    {
        public NodeProperty<NumericProperty> SaveCurrencyDecrease = new NodeProperty<NumericProperty>();
        public override void OnInit()
        {
            TowerDefenseGameManager.Instance.OnCurrencyDecreaseAction += OnCurrencyDecrease;
        }

        private void OnCurrencyDecrease(int round)
        {
            SaveCurrencyDecrease.Value.IntegerValue = round;
            child.Update();
        }
    }
}