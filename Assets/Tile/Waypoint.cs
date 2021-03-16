using UnityEngine;

namespace Tile
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private Tower.Tower tower;
        
        [SerializeField] private bool isPlaceable = true;
        public bool IsPlaceable => isPlaceable && towerAtThisTile == null;

        private GameObject towerAtThisTile;
        private void OnMouseDown()
        {
            if (isPlaceable && towerAtThisTile == null)
            {
                towerAtThisTile = tower.CreateTower(transform.position);
            }
        }
    }
}
