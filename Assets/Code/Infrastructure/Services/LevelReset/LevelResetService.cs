using System;
using System.Collections.Generic;
using Code.Core.Signals;
using Zenject;

namespace Code.Infrastructure.Services.LevelReset
{
    public class LevelResetService : ILevelResetService, IInitializable, IDisposable
    {
        private readonly List<ILevelReset> _resettableServices;
        private readonly SignalBus _signalBus;

        public LevelResetService(List<ILevelReset> resettableServices, SignalBus signalBus)
        {
            _resettableServices = resettableServices;
            _signalBus = signalBus;
        }

        public void Initialize() =>
            _signalBus.Subscribe<RestartGameSignal>(StartResetProcess);

        public void Dispose() =>
            _signalBus.Unsubscribe<RestartGameSignal>(StartResetProcess);

        private void StartResetProcess()
        {
            foreach (var service in _resettableServices)
                service.Reset();
        }
    }
}