using Unity.VisualScripting;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Condition")]
    [NodeTitle("Tower Defense:\nHas Round Finished")]
    [NodeMenuName("Tower Defense: Has Round Finished")] 
    [CreateBBVariable("RoundToCheck", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseHasRoundFinishedNode: ComparisonNode
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
            return TowerDefenseGameManager.Instance.HasRoundFinished(RoundToCheck.Value.IntegerValue);
        }
    }
}