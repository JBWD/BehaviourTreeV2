using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Trigger")]
    [NodeTitle("Tower Defense:\nGame Won")]
    [NodeMenuName("Tower Defense: Game Won")] 
    [System.Serializable]
    public class TowerDefenseGameWonNode : TriggerNode
    {
        
        
        public override void OnInit()
        {
            TowerDefenseGameManager.Instance.OnGameWinAction += OnGameWinAction;
        }

        private void OnGameWinAction()
        {
            child.Update();
        }
    }
}
