using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Action")]
    [NodeTitle("Tower Defense:\nGet Life")]
    [NodeMenuName("Tower Defense: Get Life")] 
    [CreateBBVariable("SaveLifeAmount", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseGetCurrentLifeNode : ActionNode
    {
        public NodeProperty<NumericProperty> SaveLifeAmount;

        protected override void OnStart()
        {
           
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (SaveLifeAmount.Value != null)
            {
                SaveLifeAmount.Value.IntegerValue = TowerDefenseGameManager.Instance.GetCurrentLives();
                return State.Success;
            }

            return State.Failure;
        }
    }
}
