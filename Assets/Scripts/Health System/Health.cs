using System;
using UnityEngine;

public class Health
{
    public event Action<int> OnDamageTakenEvent;
    public event Action<int> OnHealedEvent;
    public event Action OnDieEvent;

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public bool IsDead { get; private set; }

    private float damageEventCooldown = 1.0f;  // Cooldown period for damage event (adjust as needed)
    private float healEventCooldown = 1.0f;    // Cooldown period for heal event (adjust as needed)

    private float lastDamageEventTime;
    private float lastHealEventTime;

    public Health(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        IsDead = false;
        lastDamageEventTime = Time.time - damageEventCooldown;
        lastHealEventTime = Time.time - healEventCooldown;
    }

    public void TakeDamage(int damage)
    {
        if (Time.time - lastDamageEventTime >= damageEventCooldown)
        {
            CurrentHealth -= damage;
            OnDamageTakenEvent?.Invoke(damage);
            lastDamageEventTime = Time.time;
        }

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (IsDead)
        {
            return; // Do not heal if already dead
        }

        if (Time.time - lastHealEventTime >= healEventCooldown)
        {
            CurrentHealth += amount;
            OnHealedEvent?.Invoke(amount);
            lastHealEventTime = Time.time;
        }

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    private void Die()
    {
        if (IsDead)
        {
            return; // Do not die if already dead
        }

        IsDead = true;
        OnDieEvent?.Invoke();
    }
}