using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _healthAmount = 100;
    [SerializeField] private HealthBar _healthBar;
    
    public Health _health;

    private void Start()
    {
        // Create a new Health instance with maximum health value
        _health = new Health(_healthAmount);
        _healthBar.Init(_health);

        EventManager.Instance.GetEvent<OnDamageTaken>().intEvent += TakeDamage;
        EventManager.Instance.GetEvent<OnHealed>().intEvent += Heal;
        EventManager.Instance.GetEvent<OnDie>().simpleEvent += Die;
    }

    private void OnDestroy()
    {
        EventManager.Instance.GetEvent<OnDamageTaken>().intEvent -= TakeDamage;
        EventManager.Instance.GetEvent<OnHealed>().intEvent -= Heal;
        EventManager.Instance.GetEvent<OnDie>().simpleEvent -= Die;
    }

    // This Update is only to test 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _health.TakeDamage(5);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            _health.Heal(6);
        }
    }

    /// <summary>
    /// Handles player damage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
    }

    /// <summary>
    /// Handles player heal
    /// </summary>
    /// <param name="amount"></param>
    public void Heal(int amount)
    {
    }

    public void Die()
    {
    }
}