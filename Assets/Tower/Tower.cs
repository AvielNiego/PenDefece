using UnityEngine;
using UnityEngine.UIElements;

namespace Tower
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private int cost = 75;
        public GameObject CreateTower(Vector3 position)
        {
            var bank = FindObjectOfType<Bank.Bank>();

            if (bank == null || bank.CurrentBalance < cost)
            {
                return null;
            }
            bank.Withdraw(cost);
            return Instantiate(gameObject, position, Quaternion.identity);
        }
    }
}