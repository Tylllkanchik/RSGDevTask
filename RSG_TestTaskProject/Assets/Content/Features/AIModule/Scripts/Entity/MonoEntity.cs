using Content.Features.AIModule.Scripts.Entity.EntityBehaviours;
using Content.Features.DamageablesModule.Scripts;
using Content.Features.EntityComponentModule.Scripts;
using Content.Features.StorageModule.Scripts;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Content.Features.AIModule.Scripts.Entity {
    public class MonoEntity : MonoBehaviour, IEntity {
        [SerializeField] private EntityContext _entityContext;
        [SerializeField] private EntityType _entityType;
        [SerializeField] private bool _isAggressive;

        private List<IComponent> _entityComponents = new List<IComponent>();

        private IEntityBehaviour _currentBehaviour;
        private IEntityDataService _entityDataService;
        private IEntityBehaviourFactory _entityBehaviourFactory;

        [Inject]
        public void InjectDependencies(IEntityDataService entityDataService, IEntityBehaviourFactory entityBehaviourFactory) {
            _entityBehaviourFactory = entityBehaviourFactory;
            _entityDataService = entityDataService;
        }

        private void Start() {
            _entityContext.Entity = this;
            _entityContext.EntityDamageable = GetComponent<IDamageable>();
            _entityContext.EntityData = _entityDataService.GetEntityData(_entityType);
            _entityContext.EntityDamageable.SetHealth(_entityContext.EntityData.StartHealth);
            
            SetDefaultBehaviour();
        }

        private void Update() =>
            _currentBehaviour.Process();

        private void OnDestroy() {
            if (_currentBehaviour == null)
                return;

            _currentBehaviour.Stop();
            _currentBehaviour.OnBehaviorEnd -= OnBehaviourEnded;
        }

        public void Bind(List<IComponent> components)
        {
            _entityComponents = components;
            var entityComponents = gameObject.GetComponentsInChildren<IMonoComponent>();
            foreach (var component in entityComponents) {
                var componentToBind = components.Find(c => c.GetType() == component.ComponentType);
                if (componentToBind != null) { 
                    component.Bind(componentToBind);
                }
            }
        }

        public bool TryGetEntityComponent<T>(out T component) where T : IComponent
        {
            component = default;
            for(int i = 0; i < _entityComponents.Count; i++)
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

        public void SetBehaviour(IEntityBehaviour entityBehaviour) {
            if(_currentBehaviour != null) {
                _currentBehaviour.Stop();
                _currentBehaviour.OnBehaviorEnd -= OnBehaviourEnded;
            }
            _currentBehaviour = entityBehaviour;
            _currentBehaviour.OnBehaviorEnd += OnBehaviourEnded;
            _currentBehaviour.InitContext(_entityContext);
            _currentBehaviour.Start();
        }

        private void OnBehaviourEnded() =>
            SetDefaultBehaviour();

        private void SetDefaultBehaviour() {
            if (_isAggressive)
                SetBehaviour(_entityBehaviourFactory.GetEntityBehaviour<IdleSearchForTargetsEntityBehaviour>());
            else
                SetBehaviour(_entityBehaviourFactory.GetEntityBehaviour<IdleEntityBehaviour>());
        }
    }
}