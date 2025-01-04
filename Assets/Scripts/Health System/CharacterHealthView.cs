using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Slider healthSlider;

    public void UpdateHealthDisplay(int currentHealth, int maxHealth, Guid entityGuid)
    {
        Debug.Log($"Entity {entityGuid.ToString()} got damaged");
        healthText.text = "Health " + currentHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void UpdateDeathDisplay(Guid entityGuid)
    {
        Debug.Log($"Entity {entityGuid} has died");
    }
}