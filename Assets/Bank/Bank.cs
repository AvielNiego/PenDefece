using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Bank
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private int startingBalance = 150;
        
        [SerializeField] private int currentBalance;
        public int CurrentBalance => currentBalance;

        [SerializeField] private TextMeshProUGUI displayBalance;

        private void Awake()
        {
            currentBalance = startingBalance;
            UpdateDisplay();
        }

        public void Deposite(int amount)
        {
            if (amount <= 0)
            {
                return;
            }
            
            UpdateBalance(amount);
        }

        public void Withdraw(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            UpdateBalance(-amount);
            
            if (currentBalance < 0)
            {
                ReloadScene();
            }
        }

        private void UpdateBalance(int amount)
        {
            currentBalance += amount;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            displayBalance.text = $"Gold: {currentBalance}";
        }

        private static void ReloadScene()
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }     

}