using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Content.Features.StorageModule.Scripts {
    [CreateAssetMenu(menuName = "Configurations/Inventory/" + nameof(StoragesConfiguration), 
        fileName = nameof(StoragesConfiguration) + "_Default", order = 0)]
    public class StoragesConfiguration : ScriptableObject {
        [SerializeField] private StandardStorageConfiguration _standardStorageConfiguration;

        public StandardStorageConfiguration GetStandardStorageConfiguration() {
            return _standardStorageConfiguration;
        }
    }
}