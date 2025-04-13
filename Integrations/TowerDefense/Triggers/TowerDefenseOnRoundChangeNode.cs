namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Trigger")]
    [NodeTitle("Tower Defense:\nOn Round Change")]
    [NodeMenuName("Tower Defense: On Round Change")] 
    [CreateBBVariable("SaveRoundChange", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseOnRoundChangeNode :TriggerNode
    {
        public NodeProperty<NumericProperty> SaveRoundChange;
        public override void OnInit()
        {
            TowerDefenseGameManager.Instance.OnRoundChangeAction += OnRoundChange;
        }

        private void OnRoundChange(int round)
        {
            SaveRoundChange.Value.IntegerValue = round;
            child.Update();
        }
    }
}