using Event_Manager.Events;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterHealthController : MonoBehaviour
{
    [SerializeField] private CharacterHealthView characterHealthView;
    private HealthModel _healthModel;
    private EventManager _eventManager;

    private void Start()
    {
        _eventManager = EventManager.Instance;
        _healthModel = new HealthModel(100, _eventManager);
        
        _eventManager.Register<HealthChangedEvent>(OnHealthChanged);
        _eventManager.Register<DiedEvent>(OnPlayerDied);

        characterHealthView.UpdateHealthDisplay(_healthModel.GetCurrentHealth(), _healthModel.GetMaxHealth(), _healthModel.GetEntityGuid());
    }

    public void TakeDamage(int amount)
    {
        _healthModel.TakeDamage(amount);
    }

    public void Heal(int amount)
    {
        _healthModel.Heal(amount);
    }

    private void OnHealthChanged(HealthChangedEvent evt)
    {
        characterHealthView.UpdateHealthDisplay(evt.CurrentHealth, evt.MaxHealth, evt.EntityGuid);
    }

    private void OnPlayerDied(DiedEvent evt)
    {
        characterHealthView.UpdateDeathDisplay(evt.EntityGuid);
    }

    private void OnDestroy()
    {
        _eventManager.Unregister<HealthChangedEvent>(OnHealthChanged);
        _eventManager.Unregister<DiedEvent>(OnPlayerDied);
    }
}