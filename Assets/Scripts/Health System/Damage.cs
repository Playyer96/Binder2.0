using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out CharacterHealthController playerHealthController))
        {
            playerHealthController.TakeDamage(damageAmount);
        }
    }
}