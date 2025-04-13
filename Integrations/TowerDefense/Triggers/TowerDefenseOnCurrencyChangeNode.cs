using UnityEngine.Serialization;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Trigger")]
    [NodeTitle("Tower Defense:\nOn Currency Change")]
    [NodeMenuName("Tower Defense: On Currency Change")] 
    [CreateBBVariable("SaveCurrencyChange", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseOnCurrencyChangeNode : TriggerNode
    { 
        public NodeProperty<NumericProperty> SaveCurrencyChange;
        public override void OnInit()
        {
            TowerDefenseGameManager.Instance.OnCurrencyChangeAction += OnCurrencyChange;
        }

        private void OnCurrencyChange(int round)
        {
            SaveCurrencyChange.Value.IntegerValue = round;
            child.Update();
        }
    }
}