﻿using Models;
using Models.Enums;

namespace DataAccess
{
    // Static Database with multiple StorageSets that represent Tables/Collecion per type (StaticDb)
    public static class Storage
    {
        public static StorageSet<User> Users { get; set; } = new StorageSet<User>()
        {
            Items = new List<User>() {new User(1, "Admin", "Admin", "admin", "admin123", RoleEnum.Admin)}
        };
        public static StorageSet<Car> Cars { get; set; } = new StorageSet<Car>();
    }
}
