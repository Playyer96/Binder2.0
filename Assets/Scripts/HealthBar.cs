using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    private float maxHealth = 100;

    void Start()
    {
        // Register for health update events
        // EventManager<Health>.RegisterEvent(EventKey.UPDATE_HEALTH, UpdateHealth);
    }

    void UpdateHealth(Health health)
    {
        healthSlider.value = health.currenthealth / maxHealth;
    }

    private void OnDestroy()
    {
        //Unregister from events when the object is destroyed
        // EventManager<Health>.UnregisterEvent(EventKey.UPDATE_HEALTH, UpdateHealth);
    }
}
