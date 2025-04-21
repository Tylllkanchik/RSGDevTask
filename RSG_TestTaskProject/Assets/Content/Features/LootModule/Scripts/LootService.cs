using Content.Features.ItemsModule.Scripts;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.LootModule.Scripts {
    public class LootService : ILootService {
        private IItemFactory _itemFactory;

        public LootService(IItemFactory itemFactory) =>
            _itemFactory = itemFactory;

        public bool TryCollectLoot(Loot loot, IStorage storage) {

            if(CanAddAllItems(loot, storage))
            {
                foreach (ItemType itemType in loot.GetItemsInLoot())
                {
                    var item = _itemFactory.GetItem(itemType);
                    if (storage.CanAddItem(item))
                    {
                        storage.AddItem(item);
                    }
                }

                return true;
            }

            return false;
        }

        private bool CanAddAllItems(Loot loot, IStorage storage)
        {
            foreach (ItemType itemType in loot.GetItemsInLoot())
            {
                var item = _itemFactory.GetItem(itemType);
                if (!storage.CanAddItem(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}