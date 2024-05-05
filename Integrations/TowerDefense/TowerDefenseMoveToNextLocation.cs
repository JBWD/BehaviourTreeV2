using Halcyon;
using Unity.VisualScripting;
using UnityEngine;

namespace Addons.TowerDefense
{
    [BehaviourTreeNode(menuName = "Tower Defense: Move to Next Location", nodeTitle = "Tower Defense:\nMove To Next Location", nodeColor =  NodeColors.green, nodeIcon = NodeIcons.action, menuPath = "Tower Defense")]
    
    public class TowerDefenseMoveToNextLocation : ActionNode
    {
        [Tooltip("GameObject that has a 'MoveToLocation.cs' script attached.")]
        [BlackboardValueOnly]
        public NodeProperty<GameObject> scriptHolder;

        private GameObject cachedObject = null;
        private MoveToLocation mtl;
        
        public NodeProperty<Transform> saveTransform;
        public NodeProperty<Vector3> saveNextPosition;

        protected override void OnStart()
        {
           
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (scriptHolder.Value != cachedObject)
            {
                mtl = scriptHolder.Value.GetComponent<MoveToLocation>();
            }
            
            if (mtl != null)
            {
                cachedObject = scriptHolder.Value;
                saveTransform.Value = mtl.GetDestinationTransform();
                saveNextPosition.Value = mtl.GetDestinationPosition();
                state = State.Success;
            }
            else
            {
                state = State.Failure;
            }
            return state;


        }
    }
}