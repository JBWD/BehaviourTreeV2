using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Trigger")]
    [NodeTitle("Tower Defense:\nRound Started")]
    [NodeMenuName("Tower Defense: Round Started")] 
    [CreateBBVariable("SaveCurrentRound", BBVariableType.Number)]
    [System.Serializable]
    public class TowerDefenseRoundStartedNode : TriggerNode
    {
        public NodeProperty<NumericProperty> SaveCurrentRound = new NodeProperty<NumericProperty>();
        
        public override void OnInit()
        {
            TowerDefenseGameManager.Instance.OnRoundStartAction += OnRoundStarted;
        }

        private void OnRoundStarted(int obj)
        {
            SaveCurrentRound.Value.IntegerValue = obj;
            child.Update();
        }
    }
}
