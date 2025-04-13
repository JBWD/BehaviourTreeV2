namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Action")]
    [NodeTitle("Tower Defense:\nGet Current Round")]
    [NodeMenuName("Tower Defense: Get Current Round")] 
    [CreateBBVariable("SaveCurrentRound", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseGetCurrentRoundNode :ActionNode
    {
        
        public NodeProperty<NumericProperty> SaveCurrentRound;

        protected override void OnStart()
        {
           
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (SaveCurrentRound.Value != null)
            {
                SaveCurrentRound.Value.IntegerValue = TowerDefenseGameManager.Instance.GetCurrentRound();
                return State.Success;
            }

            return State.Failure;
        }
    }
}