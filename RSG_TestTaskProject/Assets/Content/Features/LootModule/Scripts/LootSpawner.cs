using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Content.Features.LootModule.Scripts {
    public class LootSpawner : MonoBehaviour {
        [SerializeField] private List<Loot> _lootToSpawn;
        private DiContainer _diContainer;

        [Inject]
        public void InjectDependencies(DiContainer diContainer) =>
            _diContainer = diContainer;

        public void SpawnLoot() {
            int sumChances = 0;
            var lootToSpawn = _lootToSpawn.OrderBy(l => l.SpawnChance).ToList();

            foreach (var l in lootToSpawn)
                sumChances += l.SpawnChance;

            int randomWeight = Random.Range(0, sumChances);
            var loot = lootToSpawn[0];

            foreach (var obj in lootToSpawn)
            {
                if (randomWeight < obj.SpawnChance)
                {
                    loot = obj;
                    break;
                }
                randomWeight -= obj.SpawnChance;
            }

            _diContainer.InstantiatePrefab(loot.gameObject, transform.position, Quaternion.identity, null);
        }
    }
}