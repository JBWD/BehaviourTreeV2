using Unity.VisualScripting;
using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Trigger Nodes", nodeTitle = "On Trigger Enter", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnTriggerEnterNode : TriggerNode
    {

        public NodeProperty<Collider> collider;

        public override void OnInit()
        {
            context.behaviourTreeInstance.On3DTriggerEnter += SaveCollisionAndRunNode;
        }

        public void SaveCollisionAndRunNode(Collider collider)
        {
            this.collider.Value = collider;
            OnUpdate();
        }

        public override void UpdateDescription()
        {
        }

        public override void OnDrawGizmos()
        {
            Gizmos.DrawCube(context.gameObject.transform.position, new Vector3(1,1,1));
        }
    }
}