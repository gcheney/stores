using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetAllStores();

        Store GetStore(int storeNumber);

        bool AddStore(Store store);

        void UpdateStore(int storeNumber, Store store);

        void DeleteStore(int storeNumber);
    }
}