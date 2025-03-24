using System;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.Combat
{

    public class ProjectilePooler : MonoBehaviour
    {

        public static ProjectilePooler Instance;

        public Projectile defaultProjectilePrefab;
        public int defaultPoolSize = 30;
        public List<ProjectilePoolerObject> projectileSets = new List<ProjectilePoolerObject>();

        [Serializable]
        public class ProjectilePoolerObject
        {
            public ProjectileType projectileType;
            public Projectile prefab;
            public int poolSize;
            public bool autoIncreasePoolSize;
            public List<Projectile> pool = new List<Projectile>();
            [HideInInspector] public Transform parent;

            public void Initialize()
            {
                if (prefab == null)
                {
                    Debug.LogWarning("ProjectilePooler: Projectile Pooler prefab is null");
                    return;
                }

                int creationAmount = poolSize - pool.Count;
                for (int i = 0; i < creationAmount; i++)
                {
                    Projectile projectile = Instantiate(prefab, parent);
                    projectile.name = projectileType.ToString() + ":PoolClone";
                    projectile.gameObject.SetActive(false);
                    pool.Add(projectile);
                }
            }

            public Projectile GetProjectile()
            {
                Projectile returnProjectile = null;
                for (int i = 0; i < pool.Count; i++)
                {
                    if (!pool[i].isActiveAndEnabled)
                    {
                        returnProjectile = pool[i];
                    }
                }

                if (returnProjectile == null && autoIncreasePoolSize)
                {
                    returnProjectile = Instantiate(prefab, parent);
                    returnProjectile.name = projectileType.ToString() + ":PoolClone";
                    returnProjectile.gameObject.SetActive(false);
                    pool.Add(returnProjectile);
                }

                return returnProjectile;
            }

        }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this);
            }
        }

        void Start()
        {
            if (!HasProjectileType(ProjectileType.Default))
            {
                ProjectilePoolerObject defaultPool = new ProjectilePoolerObject()
                {
                    projectileType = ProjectileType.Default,
                    poolSize = defaultPoolSize,
                    parent = transform,
                    prefab = defaultProjectilePrefab,
                    autoIncreasePoolSize = true
                };
                defaultPool.Initialize();
                projectileSets.Add(defaultPool);
            }

            foreach (ProjectilePoolerObject projectileSet in projectileSets)
            {
                if (projectileSet.poolSize > 0 && projectileSet.poolSize > projectileSet.pool.Count)
                {
                    projectileSet.parent = transform;
                    projectileSet.Initialize();
                }
            }
        }




        public Projectile GetProjectile(ProjectileType projectileType)
        {
            foreach (ProjectilePoolerObject projectilePool in projectileSets)
            {
                if (projectilePool.projectileType == projectileType)
                {
                    return projectilePool.GetProjectile();
                }
            }
            
            foreach (ProjectilePoolerObject projectilePool in projectileSets)
            {
                if (projectilePool.projectileType == ProjectileType.Default)
                {
                    return projectilePool.GetProjectile();
                }
            }
            
            return null;
        }

        public bool HasProjectileType(ProjectileType projectileType)
        {
            bool hasProjectileType = false;
            foreach (ProjectilePoolerObject projectile in projectileSets)
            {
                if (projectile.projectileType == projectileType)
                    hasProjectileType = true;
            }

            return hasProjectileType;
        }
    }
}