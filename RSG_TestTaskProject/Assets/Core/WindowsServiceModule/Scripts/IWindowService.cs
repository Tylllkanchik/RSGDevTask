using Cysharp.Threading.Tasks;

namespace Core.WindowServiceModule.Scripts
{
    public interface IWindowService
    {
        UniTask<Window> LoadWindow<T>() where T : Window;
        UniTask<Window> OpenWindow<T>() where T : Window;
        UniTask CloseWindow<T>() where T : Window;
        bool TryGetWindow<T>(out T window) where T : Window;
    }
}