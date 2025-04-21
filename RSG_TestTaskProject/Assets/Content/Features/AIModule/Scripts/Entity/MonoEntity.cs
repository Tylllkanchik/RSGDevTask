using Content.Features.AIModule.Scripts.Components;
using Content.Features.DamageablesModule.Scripts;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Content.Features.AIModule.Scripts.Entity
{
    public class MonoEntity : MonoBehaviour, IEntity
    {
        [SerializeField] private EntityType _entityType;

        private List<IComponent> _entityComponents = new List<IComponent>();
        private IEntityDataService _entityDataService;

        [SerializeField] protected EntityContext _entityContext;

        protected IEntityBehaviourFactory _entityBehaviourFactory;

        [Inject]
        public void InjectDependencies(IEntityDataService entityDataService, IEntityBehaviourFactory entityBehaviourFactory)
        {
            _entityBehaviourFactory = entityBehaviourFactory;
            _entityDataService = entityDataService;
        }

        public virtual void Bind(List<IComponent> components)
        {
            _entityComponents = components;
            var entityComponents = gameObject.GetComponentsInChildren<IMonoComponent>();
            foreach (var component in entityComponents)
            {
                var componentToBind = components.Find(c => c.GetType() == component.ComponentType);
                if (componentToBind != null)
                {
                    component.Bind(componentToBind);
                }
                else
                {
                    var bindedComponent = component.BindNewComponent();
                    _entityComponents.Add(bindedComponent);
                }
            }

            _entityContext.Entity = this;
            _entityContext.EntityDamageable = GetComponent<IDamageable>();
            _entityContext.EntityData = _entityDataService.GetEntityData(_entityType);
        }

        public bool TryGetEntityComponent<T>(out T component) where T : IComponent
        {
            component = default;
            for (int i = 0; i < _entityComponents.Count; i++)
            {
                IComponent entityComponent = _entityComponents[i];
                if (entityComponent is T com)
                {
                    component = com;
                    return true;
                }
            }

            return false;
        }

        public virtual void SetBehaviour(IEntityBehaviour entityBehaviour)
        {
            
        }
    }
}
