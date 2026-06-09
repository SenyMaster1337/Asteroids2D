using Code.Core.Interfaces.Score;
using R3;
using Zenject;

namespace Code.Infrastructure.Services.ScoreService
{
    public class ScoreService : IInitializable, IScoreService
    {
        public ReadOnlyReactiveProperty<int> ScoreValue => _score;

        private readonly ReactiveProperty<int> _score = new();

        public void Initialize()
            => _score.Value = 0;

        public void AddScore(int value)
            => _score.Value += value;
    }
}