using Code.StaticData;

namespace Code.Infrastructure.Services.Reward
{
    public interface IRewardService
    {
        void GiveReward(EnemyType type);
    }
}