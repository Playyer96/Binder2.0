using UnityEngine;

public class Damage : MonoBehaviour
{
    private HealthManager _healthManager;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out _healthManager))
        {
            // Invoke the TakeDamage method of the specific HealthManager instance
            _healthManager.TakeDamage(1);
        }
    }
}