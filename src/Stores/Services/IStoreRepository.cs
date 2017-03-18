using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetStores();

        Store GetStore(int storeNumber);

        void AddStore(Store store);

        void UpdateStore(int storeNumber, Store store);

        void DeleteStore(int storeNumber);
    }
}