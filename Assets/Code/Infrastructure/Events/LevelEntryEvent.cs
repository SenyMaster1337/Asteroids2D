using System;

namespace Code.Infrastructure.Events
{
    public class LevelEntryEvent
    {
        public event Action OnLevelEntry;

        public void Notify()
            => OnLevelEntry?.Invoke();
    }
}