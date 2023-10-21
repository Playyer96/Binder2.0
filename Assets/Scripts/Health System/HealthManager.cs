using System;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _healthAmount = 100;
    [SerializeField] private HealthBar _healthBar;
    
    public Health _health;

    private void Start()
    {
        // Create a new Health instance with maximum health value
        _health = new Health(_healthAmount);
        _healthBar.Init(_health);
    }

    /// <summary>
    /// Handles player damage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    /// <summary>
    /// Handles player heal
    /// </summary>
    /// <param name="amount"></param>
    public void Heal(int amount)
    {
        _health.Heal(amount);
    }

    public void Die()
    {
        
    }
}