using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.Services.Analytics
{
    public interface IFirebaseInitializeService
    {
        UniTask InitializeAsync();
    }
}