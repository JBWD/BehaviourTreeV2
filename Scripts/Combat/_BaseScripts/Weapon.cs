using System;
using Halcyon.BT.Integrations.Combat;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Halcyon.Combat
{
    
    public class Weapon : MonoBehaviour
    {
        public enum WeaponType
        {
            Primary,
            Secondary,
            Special,
        }

        public enum WeaponStyle
        {
            Melee,
            Ranged,
            Healing,
        }

        public bool drawGizmos = true;
        public WeaponType weaponType;
        public WeaponStyle weaponStyle;
        public Transform rotationalTransform;

        [Header("Base Information")] public LayerMask hitLayers;
        public float cooldown;
        public float resourceCost;

        public float castTime;
        public bool canMoveWhileCasting;
        public bool isMoving = false;

        [Header("Melee Information")] public float meleeDamage;
        public Vector3 meleeOffset = new Vector3(0, 1, 1);
        public bool useSphere = false;
        public Vector3 boxSize = Vector3.one;
        public float sphereSize = 2f;

        [Header("Ranged Information")] public Vector3 projectileSpawnOffset = new Vector3(0, 1, 1);
        public ProjectileType projectileType;
        public float rangedDamage;
        public float range;
        public float poolTransform;
        public bool poolOnStart;
        public bool autoIncreasePoolSize;
        public int numberToPool;

        [Header("Healing Information")] public float healingAmount;

        [Header("Buff Information")] public int buffID;


        private float currentCooldownTime = 0;
        [Range(0, 100)] public float finisherPercentage = 20f;

        public void OnDrawGizmosSelected()
        {
            if (!drawGizmos) return;
            switch (weaponStyle)
            {
                case WeaponStyle.Melee:
                    if (useSphere)
                        Gizmos.DrawWireSphere(
                            rotationalTransform
                                ? RotatePointAroundOrigin(transform.position + meleeOffset, transform.position,
                                    Vector3.up, rotationalTransform.rotation.eulerAngles.y)
                                : transform.position + meleeOffset, sphereSize);

                    else

                        DrawDebugBox(
                            rotationalTransform
                                ? RotatePointAroundOrigin(transform.position + meleeOffset, transform.position,
                                    Vector3.up, rotationalTransform.rotation.eulerAngles.y)
                                : transform.position + meleeOffset,
                            rotationalTransform ? rotationalTransform.forward : transform.forward,
                            rotationalTransform ? rotationalTransform.rotation : transform.rotation, .25f);
                    break;
                case WeaponStyle.Ranged:
                    Gizmos.color = new Color(.8f, .1f, .1f, .8f);
                    Gizmos.DrawRay(
                        rotationalTransform
                            ? RotatePointAroundOrigin(transform.position + projectileSpawnOffset, transform.position,
                                Vector3.up, rotationalTransform.rotation.eulerAngles.y)
                            : transform.position + projectileSpawnOffset,
                        rotationalTransform ? rotationalTransform.forward * range : transform.forward * range);
                    DrawDebugRange();
                    break;
                case WeaponStyle.Healing:
                    break;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        void DrawDebugRange()
        {
            Matrix4x4 oldMatrix = Gizmos.matrix;
            Gizmos.color = new Color(.8f, .1f, .1f, .4f); //this is gray, could be anything
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1, .001f, 1));
            Gizmos.DrawSphere(Vector3.zero, range);
            Gizmos.matrix = oldMatrix;
        }

        void DrawDebugBox(Vector3 origin, Vector3 direction, Quaternion rotation, float distance)
        {
            // Draw the start box
            Gizmos.color = Color.red;
            Matrix4x4 startMatrix = Matrix4x4.TRS(origin, rotation, boxSize);
            Gizmos.matrix = startMatrix;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

            // Draw the end box
            Gizmos.color = Color.green;
            Matrix4x4 endMatrix = Matrix4x4.TRS(origin + direction * distance, rotation, boxSize);
            Gizmos.matrix = endMatrix;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

            // Reset the Gizmos matrix
            Gizmos.matrix = Matrix4x4.identity;
        }

        public void Update()
        {
            currentCooldownTime += Time.deltaTime;
        }

        
        public void OnMovement(InputValue value)
        {
            var move = value.Get<Vector2>();
            isMoving = move.x != 0 || move.y != 0;
        }


        public void OnPrimaryWeapon(InputValue value)
        {
            Debug.Log("Firing Primary Weapon");
            if (weaponType != WeaponType.Primary)
                return;
            UseWeapon();
        }

        public void OnSecondaryWeapon(InputValue value)
        {
            Debug.Log("Firing Secondary Weapon");
            if (weaponType != WeaponType.Secondary)
                return;
            UseWeapon();
        }

        public void OnSpecialWeapon(InputValue value)
        {
            Debug.Log("Firing Special Weapon");
            if (weaponType != WeaponType.Special)
                return;
            UseWeapon();
        }

        public void UseWeapon()
        {
            if (currentCooldownTime < cooldown)
                return;
            
            currentCooldownTime = 0;
            
            switch (weaponStyle)
            {
                case WeaponStyle.Melee:
                    UseMeleeWeapon();
                    break;
                case WeaponStyle.Ranged:
                    UseRangedWeapon();
                    break;
                case WeaponStyle.Healing:
                    UseHealingWeapon();
                    break;
            }

        }


        private void UseMeleeWeapon()
        {
            RaycastHit[] hits = Array.Empty<RaycastHit>();
            if (useSphere)
            {
                hits = Physics.SphereCastAll(
                    rotationalTransform
                        ? RotatePointAroundOrigin(transform.position + meleeOffset, transform.position, Vector3.up,
                            rotationalTransform.rotation.eulerAngles.y)
                        : transform.position + meleeOffset,
                    sphereSize,
                    (rotationalTransform ? rotationalTransform.forward : transform.forward),
                    .01f,
                    hitLayers);
            }
            else
            {
                hits = Physics.BoxCastAll(
                    rotationalTransform
                        ? RotatePointAroundOrigin(transform.position + meleeOffset, transform.position, Vector3.up,
                            rotationalTransform.rotation.eulerAngles.y)
                        : transform.position + meleeOffset,
                    boxSize * .5f,
                    (rotationalTransform ? rotationalTransform.forward : transform.forward) * .01f,
                    Quaternion.identity,
                    .01f, hitLayers);
            }
            
            foreach (RaycastHit hit in hits)
            {
                hit.collider.GetComponent<Health>()?.TakeDamage(meleeDamage);
            }
        }

        private void UseRangedWeapon()
        {
            var projectile = ProjectilePooler.Instance.GetProjectile(projectileType);
            projectile.Initialize(GetRangedSpawnPosition(), rotationalTransform.rotation, hitLayers);
        }

        private void UseHealingWeapon()
        {
        }

        private void UseBuffWeapon()
        {

        }

        Vector3 RotatePointAroundOrigin(Vector3 point, Vector3 origin, Vector3 axis, float angle)
        {
            // Translate the point relative to the origin
            Vector3 relativePoint = point - origin;

            // Create the rotation using a Quaternion
            Quaternion rotation = Quaternion.AngleAxis(angle, axis);

            // Apply the rotation
            Vector3 rotatedRelativePoint = rotation * relativePoint;

            // Translate back to the original position
            return rotatedRelativePoint + origin;
        }
        public Vector3 GetRangedSpawnPosition()
        {
            return rotationalTransform?
                RotatePointAroundOrigin(transform.position + projectileSpawnOffset, transform.position, Vector3.up,
                    rotationalTransform.rotation.eulerAngles.y)
                : transform.position + projectileSpawnOffset;
        }

        public Vector3 GetMeleeSpawnPosition()
        {
            return rotationalTransform?
                RotatePointAroundOrigin(transform.position + meleeOffset, transform.position, Vector3.up,
                rotationalTransform.rotation.eulerAngles.y)
                : transform.position + meleeOffset;
        }

        public bool CanFire()
        {
            return false;
        }
    }
}