using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity
{
    [RequireComponent(typeof(MonoEntity))]
    public class SceneEntityBinder : MonoBehaviour
    {
        private void Start()
        {
            var entity = GetComponent<MonoEntity>();

            entity.Bind(new System.Collections.Generic.List<Components.IComponent>());
        }
    }
}
