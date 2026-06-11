using Code.Infrastructure.Services.AdsServices;

namespace Code.Infrastructure.Services.LevelEntryProcessors
{
    public class LevelEntryProcessor : ILevelEntryProcessor
    {
        private readonly IAdsService _adsService;

        public LevelEntryProcessor(IAdsService adsService)
        {
            _adsService = adsService;
        }

        public void ProcessEntry()
            => _adsService.ShowInterAd();
    }
}