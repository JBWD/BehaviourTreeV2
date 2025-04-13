namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Condition")]
    [NodeTitle("Tower Defense:\nIs Round Running")]
    [NodeMenuName("Tower Defense: Is Round Running")] 
    [CreateBBVariable("RoundToCheck", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseIsRoundRunningNode : ComparisonNode
    {
        public NodeProperty<NumericProperty> roundNumber;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
         
        }

        public override bool CheckComparison()
        {
            return TowerDefenseGameManager.Instance.IsRoundRunning(roundNumber.Value.IntegerValue);
        }
        
    }
}