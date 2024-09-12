using UnityEngine;


namespace Halcyon.BT.Integrations.Combat
{
    public class Combat_TargetEnteredRangeNode: OnTriggerEnterNode
    {
        
        public override void SaveCollisionAndRunNode(Collider collider)
        {
            base.SaveCollisionAndRunNode(collider);
        }
    }
}