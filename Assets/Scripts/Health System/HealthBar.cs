using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Slider healthSlider;

    private Health health;

    public void Init(Health health)
    {
        this.health = health;

        // Subscribe to the events of the Health instance
        health.OnDamageTakenEvent += UpdateUI;
        health.OnHealedEvent += UpdateUI;
        health.OnDieEvent += HandleDeath;
        // UpdateUI(health.CurrentHealth);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the events when the object is destroyed
        health.OnDamageTakenEvent -= UpdateUI;
        health.OnHealedEvent -= UpdateUI;
        health.OnDieEvent -= HandleDeath;
    }

    public void UpdateUI(int value)
    {
        healthText.text = "Health " + value;
        healthSlider.maxValue = health.MaxHealth;
        healthSlider.value = value;
    }

    public void HandleDeath()
    {
        // Handle death-related UI changes here if needed
    }
}