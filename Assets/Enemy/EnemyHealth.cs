using System;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int startHealth = 25;
        [Tooltip("Adds amount to startHealth when enemy die")]
        [SerializeField] private int difficultyRamp = 5;
        [SerializeField] private int hitDamage = 5;

        private Enemy enemy;
        private int currentHealth;
        
        private void OnEnable()
        {
            currentHealth = startHealth;
        }

        private void Start()
        {
            enemy = GetComponent<Enemy>();
        }

        private void OnParticleCollision(GameObject other)
        {
            ProcessHit();
        }

        private void ProcessHit()
        {
            currentHealth -= hitDamage;
            if (currentHealth > 0) return;
            
            gameObject.SetActive(false);
            enemy.RewardGold();
            startHealth += difficultyRamp;
        }
    }
}
