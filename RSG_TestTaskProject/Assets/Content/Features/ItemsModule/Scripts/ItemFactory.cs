namespace Content.Features.ItemsModule.Scripts {
    public class ItemFactory : IItemFactory {
        private readonly ItemsConfiguration _itemsConfiguration;

        public ItemFactory(ItemsConfiguration itemsConfiguration) =>
            _itemsConfiguration = itemsConfiguration;

        public Item GetItem(ItemType itemType) =>
            new (_itemsConfiguration.GetItemConfiguration(itemType));
    }
}