namespace Content.Features.ItemsModule.Scripts {
    public interface IItemFactory {
        public Item GetItem(ItemType itemType);
    }
}