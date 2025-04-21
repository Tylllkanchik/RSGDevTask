using Content.Features.StorageModule.Scripts;

namespace Content.Features.LootModule.Scripts {
    public interface ILootService {
        bool TryCollectLoot(Loot loot, IStorage storage);
    }
}