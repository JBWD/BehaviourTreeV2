namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Condition")]
    [NodeTitle("Tower Defense:\nHas Round Started")]
    [NodeMenuName("Tower Defense: Has Round Started")] 
    [CreateBBVariable("RoundToCheck", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseHasRoundStartedNode: ComparisonNode
    {
        
        public NodeProperty<NumericProperty> RoundToCheck = new NodeProperty<NumericProperty>();
        

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        public override bool CheckComparison()
        {
            return TowerDefenseGameManager.Instance.HasRoundStarted(RoundToCheck.Value.IntegerValue);
        }
    }
}