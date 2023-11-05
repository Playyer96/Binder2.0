using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private HealthBar healthBar;
    private Health health;

    private void Start()
    {
        health = new Health(maxHealth);

        // Now, you can safely update the UI using the Init method
        healthBar.Init(health);
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