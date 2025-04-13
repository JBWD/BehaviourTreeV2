namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Trigger")]
    [NodeTitle("Tower Defense:\nOn Gain Life")]
    [NodeMenuName("Tower Defense: On Gain Life")] 
    [CreateBBVariable("SaveGainLife", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseOnGainLifeNode:TriggerNode
    {
        public NodeProperty<NumericProperty> SaveGainLife = new NodeProperty<NumericProperty>();
        public override void OnInit()
        {
            TowerDefenseGameManager.Instance.OnGainLifeAction += OnGainLife;
        }

        private void OnGainLife(int round)
        {
            SaveGainLife.Value.IntegerValue = round;
            child.Update();
        }
    }
}