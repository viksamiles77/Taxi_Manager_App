using Models;

namespace DataAccess
{
    // Static Database with multiple StorageSets that represent Tables/Collecion per type (StaticDb)
    public static class Storage
    {
        public static StorageSet<User> Users { get; set; } = new StorageSet<User>();
        public static StorageSet<Car> Cars { get; set; } = new StorageSet<Car>();
    }
}
