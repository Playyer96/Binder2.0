using System;

namespace Event_Manager.Events
{
    public class HealthChangedEvent
    {
        public int CurrentHealth { get; }
        public int MaxHealth { get; }
        public Guid EntityGuid { get; }

        public HealthChangedEvent(int currentHealth, int maxHealth, Guid entityGuid)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
            EntityGuid = entityGuid;
        }
    }

    public class DiedEvent
    {
        public Guid EntityGuid { get; }

        public DiedEvent(Guid entityGuid)
        {
            EntityGuid = entityGuid;
        }
    }
}