using UnityEngine;

public class Health
{
    public int MaxHealth { get; private set; }

    public int CurrentHealth { get; private set; }


    public Health(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            Die();
        }
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    public void Die()
    {
        Debug.Log($"Player died!!");
    }
}