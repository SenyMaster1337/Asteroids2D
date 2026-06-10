using System;
using Code.Core.Interfaces.Score;
using MVVM;
using R3;
using Zenject;

namespace Code.UI.ViewModels
{
    public class ScoreViewModel : IInitializable, IDisposable
    {
        [Data("Score")] 
        public readonly ReactiveProperty<string> Score = new();

        private readonly IScoreService _scoreService;
        private IDisposable _subscription;

        public ScoreViewModel(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        public void Initialize()
        {
            Score.Value = _scoreService.ScoreValue.CurrentValue.ToString();
            _subscription = _scoreService.ScoreValue.Subscribe(value => Score.Value = value.ToString());
        }

        public void Dispose()
            => _subscription?.Dispose();
    }
}