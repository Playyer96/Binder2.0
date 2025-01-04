using System;
using Event_Manager.Events;
using UnityEngine;

public class HealthModel
{
    private readonly int _maxHealth;
    private int _currentHealth;
    private readonly EventManager _eventManager;
    private readonly Guid _entityGuid;

    public HealthModel(int maxHealth, EventManager eventManager)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        _eventManager = eventManager;
        _entityGuid = Guid.NewGuid();
    }

    public void TakeDamage(int amount)
    {
        if (_currentHealth <= 0) return;

        _currentHealth = Mathf.Max(_currentHealth - amount, 0);
        _eventManager.Invoke(new HealthChangedEvent(_currentHealth, _maxHealth, _entityGuid));

        if (_currentHealth <= 0)
        {
            _eventManager.Invoke(new DiedEvent(_entityGuid));
        }
    }

    public void Heal(int amount)
    {
        if (_currentHealth <= 0) return;

        _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);
        _eventManager.Invoke(new HealthChangedEvent(_currentHealth, _maxHealth, _entityGuid));
    }

    public int GetCurrentHealth() => _currentHealth;
    public int GetMaxHealth() => _maxHealth;
    public Guid GetEntityGuid() => _entityGuid;
}