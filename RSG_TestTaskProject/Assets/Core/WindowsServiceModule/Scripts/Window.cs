using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.WindowServiceModule.Scripts
{
    public abstract class Window : MonoBehaviour
    {
        public virtual UniTask Open()
        {
            gameObject.SetActive(true);
            return UniTask.CompletedTask;
        }
        
        public virtual UniTask Close()
        {
            gameObject.SetActive(false);
            return UniTask.CompletedTask;
        }
    }
}
