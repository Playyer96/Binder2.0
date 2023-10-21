using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Slider _healthSlider;

    private Health _health;

    public void Init(Health health)
    {
        _health = health;
        
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (_health != null)
        {
            // Update text displaying the current health of the player
            _healthText.text = "Health " + _health.CurrentHealth.ToString();

            // Update the max and current value of the Health for the slider
            _healthSlider.maxValue = _health.MaxHealth;
            _healthSlider.value = _health.CurrentHealth;
        }
    }
}
