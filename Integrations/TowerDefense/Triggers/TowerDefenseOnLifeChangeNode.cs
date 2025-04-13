namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Trigger")]
    [NodeTitle("Tower Defense:\nOn Life Change")]
    [NodeMenuName("Tower Defense: On Life Change")] 
    [CreateBBVariable("SaveChangeLife", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseOnLifeChangeNode: TriggerNode
    {
        public NodeProperty<NumericProperty> SaveLifeChange;
        public override void OnInit()
        {
            TowerDefenseGameManager.Instance.OnLifeChangeAction += OnLifeChange;
        }

        private void OnLifeChange(int round)
        {
            SaveLifeChange.Value.IntegerValue = round;
            child.Update();
        }
    }
}