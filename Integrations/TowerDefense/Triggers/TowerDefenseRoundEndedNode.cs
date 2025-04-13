namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Trigger")]
    [NodeTitle("Tower Defense:\nRound Ended")]
    [NodeMenuName("Tower Defense: Round Ended")] 
    [CreateBBVariable("SaveCurrentRound", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseRoundEndedNode: TriggerNode
    {
        
        public NodeProperty<NumericProperty> SaveCurrentRound = new NodeProperty<NumericProperty>();
        
        public override void OnInit()
        {
            TowerDefenseGameManager.Instance.OnRoundEndAction += OnRoundEndAction;
        }

        private void OnRoundEndAction(int obj)
        {
            SaveCurrentRound.Value.IntegerValue = obj;
            child.Update();
        }
    }
}
