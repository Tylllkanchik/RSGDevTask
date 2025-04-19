namespace Content.Features.StorageModule.Scripts {
    public class StorageFactory : IStorageFactory {

        private StoragesConfiguration _standardStorageConfiguration;

        public StorageFactory(StoragesConfiguration storagesConfiguration) {
            _standardStorageConfiguration = storagesConfiguration;
        }

        public IStorage GetStorage() =>
            new StandardStorage(_standardStorageConfiguration.GetStandardStorageConfiguration());
    }
}