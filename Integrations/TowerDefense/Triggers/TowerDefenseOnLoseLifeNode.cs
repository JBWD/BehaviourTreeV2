namespace Halcyon.BT.Integrations.TowerDefense
{ 
    [NodeMenuPath("Integrations/Tower Defense/Trigger")]
    [NodeTitle("Tower Defense:\nOn Lose Life")]
    [NodeMenuName("Tower Defense: On Lose Life")] 
    [CreateBBVariable("SaveLoseLife", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseOnLoseLifeNode: TriggerNode
    {
        public NodeProperty<NumericProperty> SaveLoseLife = new NodeProperty<NumericProperty>();
        public override void OnInit()
        {
            TowerDefenseGameManager.Instance.OnLoseLifeAction += OnLoseLife;
        }

        private void OnLoseLife(int round)
        {
            SaveLoseLife.Value.IntegerValue = round;
            child.Update();
        }
    }
}