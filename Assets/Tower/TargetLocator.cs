using JetBrains.Annotations;
using UnityEngine;

namespace Tower
{
    public class TargetLocator : MonoBehaviour
    {
        [SerializeField] private Transform weapon;
        [SerializeField] private ParticleSystem projectileParticles;
        [SerializeField] private float range = 15f;
        [CanBeNull] private Transform target;

        private void Update()
        {
            FindClosestTarget();
            AimWeapon();
        }

        private void FindClosestTarget()
        {
            var enemies = FindObjectsOfType<Enemy.Enemy>();

            if (enemies.Length == 0)
            {
                return;
            }
            
            var minDistance = Mathf.Infinity;
            Transform closestTarget = null;
            foreach (var e in enemies)
            {
                var currentDistance = Vector3.Distance(e.transform.position, transform.position);
                if (minDistance > currentDistance)
                {
                    closestTarget = e.transform;
                    minDistance = currentDistance;
                }
            }
            
            target = closestTarget;
        }

        private void AimWeapon()
        {
            if (target == null)
            {
                return;
            }
            
            weapon.LookAt(target);
            
            var currentDistance = Vector3.Distance(target.transform.position, transform.position);
            if (currentDistance < range)
            {
                Attack();
            }
            else
            {
                StopAttacking();
            }
        }

        private void Attack()
        {
            var projectileParticlesEmission = projectileParticles.emission;
            projectileParticlesEmission.enabled = true;
        }

        private void StopAttacking()
        {
            var projectileParticlesEmission = projectileParticles.emission;
            projectileParticlesEmission.enabled = false;
        }
        
    }
}