using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] protected int currentHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    [SerializeField] protected int maxHealth;

    public int MaxHealth
    {
        get { return maxHealth; }
    }

    [SerializeField] private Slider enemyHealthSlider;

    void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// TakeDamage handles the functionality for taking damage
    /// </summary>
    /// <param name="damageAmount">The amount of damage to lose, this value should be positive</param>
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateEnemyHealthSlider((float)currentHealth / (float)maxHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    /// <summary>
    /// Handles all functionality related to when health reaches or goes below zero, should perform all necessary cleanup.
    /// </summary>
    public void Die()
    {
        Destroy(gameObject);
    }

    /// Required by IHealth, enemy can't heal yet but may in future.
    public void Heal(int healingAmount)
    {
    }


    /// <summary>
    /// Updates enemy's health UI slider
    /// </summary>
    public void UpdateEnemyHealthSlider(float percentage)
    {
        enemyHealthSlider.value = percentage;
    }
}