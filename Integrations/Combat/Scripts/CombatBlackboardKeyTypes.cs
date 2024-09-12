namespace Halcyon.BT.Integrations.Combat
{
    public class CombatBlackboardKeyTypes
    {
        [System.Serializable]
        public class AttackKey : BlackboardKey<Attack>
        {
        
        }

        public class ProjectileKey : BlackboardKey<Projectile>
        {
            
        }
        public class AttackTypeKey : BlackboardKey<AttackType>
        {
            
        }

        public class ArmorTypeKey : BlackboardKey<ArmorType>
        {
            
        }
        
        public class AttackerKey : BlackboardKey<Attacker>
        {
            
        }
    }
}