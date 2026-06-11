using Code.Infrastructure.GoogleAds;

namespace Code.Infrastructure.Services.GoogleAdsShowers
{
    public class GoogleAdsShowerService : IGoogleAdsShowerService
    {
        private readonly InterAd _interAd;

        public GoogleAdsShowerService(InterAd interAd)
        {
            _interAd = interAd;
        }

        public void ShowInterAd()
            => _interAd.ShowAd();
    }
}