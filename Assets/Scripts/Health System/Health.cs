using System;

public class Health
{
    public event Action<int> OnDamageTakenEvent;
    public event Action<int> OnHealedEvent;
    public event Action OnDieEvent;

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public bool IsDead { get; private set; }

    public Health(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        IsDead = false;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        OnDamageTakenEvent?.Invoke(damage);

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            OnDieEvent?.Invoke();
        }
    }


    public void Heal(int amount)
    {
        if (IsDead)
        {
            return; // Do not heal if already dead
        }

        CurrentHealth += amount;
        OnHealedEvent?.Invoke(amount);

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