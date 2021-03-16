using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Enemy
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] [Range(0, 50)] private int poolSize = 5;
        [SerializeField] [Range(0.1f, 30f)] private float spawnTimer = 1f;

        private List<GameObject> pool;

        private void Awake()
        {
            PopulatePool();
        }

        private void Start()
        {
            StartCoroutine(InstantiateEnemies());
        }

        private IEnumerator InstantiateEnemies()
        {
            while (true)
            {
                EnableFromPool();
                yield return new WaitForSeconds(spawnTimer);
            }
        }

        private void PopulatePool()
        {
            pool = new List<GameObject>();
            foreach (var i in Enumerable.Range(0, poolSize))
            {
                var enemy = Instantiate(enemyPrefab, transform);
                enemy.SetActive(false);
                pool.Add(enemy);
            }
        }

        private void EnableFromPool()
        {
            var firstNonActiveInHierarchy = pool.FirstOrDefault(o => !o.activeInHierarchy);
            if (firstNonActiveInHierarchy != null)
            {
                firstNonActiveInHierarchy.SetActive(true);
            }
        }
    }
}