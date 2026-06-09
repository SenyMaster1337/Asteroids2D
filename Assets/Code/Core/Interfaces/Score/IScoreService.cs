using R3;

namespace Code.Core.Interfaces.Score
{
    public interface IScoreService
    {
        ReadOnlyReactiveProperty<int> ScoreValue { get; }
        void AddScore(int value);
    }
}