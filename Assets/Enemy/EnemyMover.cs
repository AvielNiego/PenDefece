using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tile;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] [Range(0f, 5f)] private float speed = 1f;
        
        private List<Waypoint> path = new List<Waypoint>();
        private Enemy enemy;

        private void OnEnable()
        {
            FindPath();
            ReturnToStart();
            StartCoroutine(FollowPath());
        }
        
        private void Start()
        {
            enemy = GetComponent<Enemy>();
        }

        private void FindPath()
        {
            path = new List<Waypoint>();
            
            var parent = GameObject.FindGameObjectWithTag("Path");
            foreach (Transform child in parent.transform)
            {
                path.AddRange(child.GetComponents<Waypoint>());                
            }
        }

        private void ReturnToStart()
        {
            var first = path.FirstOrDefault();
            if (first == null) return;
            
            transform.position = first.transform.position;
        }

        private IEnumerator FollowPath()
        {
            foreach (var w in path)
            {
                var startPosition = transform.position;
                var endPosition = w.transform.position;
            
                transform.LookAt(endPosition);

                for (var travelPercent = 0f; travelPercent < 1f; travelPercent += Time.deltaTime * speed)
                {
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
            }

            FinishPath();
        }

        private void FinishPath()
        {
            gameObject.SetActive(false);
            enemy.StealGold();
        }
    }
}