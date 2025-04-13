using Halcyon.Combat;
using UnityEngine;


namespace Halcyon.TowerDefense
{
    [CreateAssetMenu(fileName = "TowerData", menuName = "Tower Data")]
    public class TowerData : ScriptableObject
    {
       
        public string fullName;
        public int cost;
        public int sellPrice;
        public Ability AutoAttack;
        public Ability SpecialAbility;
        public Sprite icon;
        public Tower soldPrefab;
        public Tower upgrade1Prefab;
        public Tower upgrade2Prefab;
        public Tower upgrade3Prefab;
    }
}