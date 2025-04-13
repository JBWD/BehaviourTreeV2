using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [NodeMenuPath("Integrations/Tower Defense/Trigger")]
    [NodeTitle("Tower Defense:\nGame Over")]
    [NodeMenuName("Tower Defense: Game Over")] 
    [System.Serializable]
    public class TowerDefenseGameOverNode : TriggerNode
    {
        public override void OnInit()
        {
            TowerDefenseGameManager.Instance.OnGameOverAction += OnGameOverAction;
        }

        private void OnGameOverAction()
        {
            child.Update();
        }
    }
}
