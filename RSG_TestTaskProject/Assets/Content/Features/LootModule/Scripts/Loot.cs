using System.Collections.Generic;
using Content.Features.ItemsModule.Scripts;
using UnityEngine;

namespace Content.Features.LootModule.Scripts {
    public class Loot : MonoBehaviour {
        [SerializeField] private List<ItemType> _itemsInLoot;
        [SerializeField] private int _spawnChance = 1;
        public List<ItemType> GetItemsInLoot() =>
            _itemsInLoot;

        public int SpawnChance => _spawnChance;

        public void DestroyLoot() =>
            Destroy(gameObject);
    }
}