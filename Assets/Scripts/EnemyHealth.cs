using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    protected int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField]
    protected int maxHealth;
    public int MaxHealth { get { return maxHealth; } }

    [SerializeField]
    private Slider enemyHealthSlider;

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
        // would be good to do some death animation here maybe
        // remove this object from the game
        Destroy(gameObject);
    }

    /// The Heal method is required due to inheriting from the IHealth interface however the enemy does not heal, although in future if will have the capabilities to do so.
    public void Heal(int healingAmount)
    {
        // Do nothing because the enemy is not meant to heal, however if the feature was desired the script below is a starting point to implement that feature
        // currentHealth += healingAmount;
        // if (currentHealth > maxHealth)
        // {
        //     currentHealth = maxHealth;
        // }
    }

    
    public void UpdateEnemyHealthSlider(float percentage)
    {
        enemyHealthSlider.value = percentage;
    }

}