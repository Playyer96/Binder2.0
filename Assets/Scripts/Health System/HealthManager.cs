using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private HealthBar healthBar;
    private Health health;

    private void Start()
    {
        health = new Health(maxHealth);

        // Subscribe to the events from the Health instance
        health.OnDamageTakenEvent += TakeDamage;
        health.OnHealedEvent += Heal;
        health.OnDieEvent += Die;

        // Now, you can safely update the UI using the Init method
        healthBar.Init(health);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the events when the object is destroyed
        health.OnDamageTakenEvent -= TakeDamage;
        health.OnHealedEvent -= Heal;
        health.OnDieEvent -= Die;
    }

    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }

    public void Heal(int amount)
    {
        health.Heal(amount);
    }

    public void Die()
    {
        // Handle the death logic
        Destroy(gameObject);
    }
}