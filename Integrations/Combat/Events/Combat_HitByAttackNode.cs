using Halcyon.BT;
using UnityEngine;

namespace Halcyon.BT.Integrations.Combat
{
    [BehaviourTreeNode(menuPath = "Combat/Event", menuName = "Combat: Hit By Attack",
        nodeTitle = "Combat:\n Hit By Attack", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class Combat_HitByAttackNode : TriggerNode
    {
        
        public NodeProperty<Attacker> attackerType;
        [BlackboardValueOnly, Tooltip("Blackboard value you wish to have the Collider saved in.")]
        public NodeProperty<Collider> attackerCollider;
        [BlackboardValueOnly, Tooltip("Blackboard value you wish to have the Collider's Transform saved in.")]
        public NodeProperty<Transform> attackerTransform;
        [BlackboardValueOnly, Tooltip("Blackboard value you wish to have the Collider's GameObject saved in.")]
        public NodeProperty<GameObject> attackerGameObject;
        [BlackboardValueOnly]
        public NodeProperty<IAttack> attackScript;
        public override void OnInit()
        {
            
            context.BehaviourTreeRunner.On3DTriggerEnter += SaveCollisionAndRunNode;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.On3DTriggerEnter -= SaveCollisionAndRunNode;
        }

        public void SaveCollisionAndRunNode(Collider collider)
        {
            attackScript.Value = collider.gameObject.GetComponent<IAttack>();
             
            if (attackScript != null)
            {
                this.attackerCollider.Value = collider;
                this.attackerTransform.Value = collider.transform;
                this.attackerGameObject.Value = collider.transform.gameObject;
                OnUpdate();
            }
            
        }
        

        public override void UpdateDescription()
        {
            description =
                "When a collision occurs, the child node is invoked, this does not repeat like the main loop.\n\n" +
                "Note: Not all saves need to be used.";
        }
    }
}