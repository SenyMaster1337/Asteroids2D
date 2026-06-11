using Code.Infrastructure.Services.GoogleAdsShowers;

namespace Code.Infrastructure.Services.LevelEntryProcessors
{
    public class LevelEntryProcessor : ILevelEntryProcessor
    {
        private readonly IGoogleAdsShowerService _adsShower;

        public LevelEntryProcessor(IGoogleAdsShowerService adsShower)
        {
            _adsShower = adsShower;
        }

        public void ProcessEntry()
            => _adsShower.ShowInterAd();
    }
}