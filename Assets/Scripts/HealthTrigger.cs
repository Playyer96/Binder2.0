using UnityEngine;

public class HealthTrigger : MonoBehaviour
{
    private float currentHealth = 100;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Simulate damage to player (e.g., -10 health)
            currentHealth -= 10;

            // Ensure health doesn't go below zero
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }

            // Trigger the event to update the health bar
            // EventManager<Health>.TriggerEvent(EventKey.UPDATE_HEALTH, new Health(){
            //     currenthealth = currentHealth,
            //     name = "John"
            // });
        }
    }
}