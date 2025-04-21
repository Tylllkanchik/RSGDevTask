using Content.Features.AIModule.Scripts.Components;
using Content.Features.AIModule.Scripts.Entity.EntityBehaviours;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Content.Features.AIModule.Scripts.Entity {
    public class CharacterEntity : MonoEntity {
        [SerializeField] private bool _isAggressive;

        private IEntityBehaviour _currentBehaviour;

        private void Update() =>
            _currentBehaviour.Process();

        private void OnDestroy() {
            if (_currentBehaviour == null)
                return;

            _currentBehaviour.Stop();
            _currentBehaviour.OnBehaviorEnd -= OnBehaviourEnded;
        }

        public override void Bind(List<IComponent> components)
        {
            base.Bind(components);
            SetDefaultBehaviour();
        }

        public override void SetBehaviour(IEntityBehaviour entityBehaviour) {
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