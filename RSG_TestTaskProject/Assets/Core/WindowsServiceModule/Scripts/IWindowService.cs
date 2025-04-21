using Cysharp.Threading.Tasks;

namespace Core.WindowServiceModule.Scripts
{
    public interface IWindowService
    {
        UniTask<T> LoadWindow<T>() where T : Window;
        UniTask<T> OpenWindow<T>() where T : Window;
        UniTask CloseWindow<T>() where T : Window;
        bool TryGetWindow<T>(out T window) where T : Window;
    }
}