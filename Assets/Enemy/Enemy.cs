using System;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int goldReward = 25;
        [SerializeField] private int goldPenalty = 25;

        private Bank.Bank bank;

        private void Start()
        {
            bank = FindObjectOfType<Bank.Bank>();
        }

        public void RewardGold()
        {
            if(bank == null) return;
            bank.Deposite(goldReward);
        }

        public void StealGold()
        {
            if(bank == null) return;
            bank.Withdraw(goldPenalty);
        }
    }
}